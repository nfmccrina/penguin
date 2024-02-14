using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Penguin.Services.Data.Dtos;
using Penguin.Services.Data.Models;
using Penguin.Services.Exceptions;
using Album = Penguin.Services.Data.Models.Album;
using AlbumDto = Penguin.Services.Data.Dtos.Album;
using SongDto = Penguin.Services.Data.Dtos.Song;
using CoverArtDto = Penguin.Services.Data.Dtos.CoverArt;

namespace Penguin.Services.Data
{
    public interface IPenguinRepository
    {
        Task<AlbumDto> GetAlbumWithSongs(int id);
        Task<CoverArtDto> GetCoverArt(int id);
        Task<IEnumerable<GenreInfo>> GetGenres();
        Task<SongStreamingInfo> GetSongInfoForStreaming(int id);
        Task<IEnumerable<AlbumList2Item>> ListAlbums2(
            AlbumListType type,
            int? size,
            int? offset,
            int? fromYear,
            int? toYear,
            string? genre,
            int? musicFolderId);
    }

    public class PenguinRepository : IPenguinRepository
    {
        private readonly PenguinDbContext dbContext;

        public PenguinRepository(PenguinDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AlbumDto> GetAlbumWithSongs(int id)
        {
            var albumDataTask = dbContext.Albums
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(a => a.Id == id);

            var songDataTask = dbContext.Songs
                .Include(s => s.Album)
                .Where(s => s.AlbumId == id)
                .Select(s => new SongDto()
                {
                    Id = s.Id,
                    AlbumId = s.AlbumId,
                    Name = s.Name,
                    TrackNumber = s.TrackNumber,
                    Created = s.Created,
                    Duration = s.Duration,
                    CoverArtId = s.CoverArtId
                })
                .ToListAsync();

            var albumData = await albumDataTask;
            var songData = await songDataTask;

            if (albumData == null)
            {
                throw new AlbumMissingException(id);
            }

            return new AlbumDto()
            {
                Id = albumData.Id,
                Name = albumData.Name,
                Created = albumData.Created,
                Genre = albumData.Genre?.Name,
                CoverArtId = albumData.CoverArtId,
                Songs = songData
            };
        }

        public async Task<CoverArtDto> GetCoverArt(int id)
        {
            var coverArt = await dbContext.CoverArt
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (coverArt == null)
            {
                throw new CoverArtMissingException(id);
            }

            return new CoverArtDto()
            {
                Type = coverArt.Type,
                Data = coverArt.Data
            };
        }

        public async Task<IEnumerable<GenreInfo>> GetGenres()
        {
            return await dbContext.Songs
                .Include(s => s.Genre)
                .Where(s => s.GenreId.HasValue)
                .GroupBy(s => s.Genre!.Name, (genreName, songs) => new GenreInfo {
                    Name = genreName,
                    SongCount = songs.Count(),
                    AlbumCount = songs.GroupBy(s => s.AlbumId).Count()
                }).ToListAsync();
        }

        public async Task<SongStreamingInfo> GetSongInfoForStreaming(int id)
        {
            var song = await dbContext.Songs
                .Include(s => s.Library)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            if (song == null)
            {
                throw new SongMissingException(id);
            }

            return new SongStreamingInfo()
            {
                Path = song.Path,
                LibraryPath = song.Library?.Path
            };
        }

        public async Task<IEnumerable<AlbumList2Item>> ListAlbums2(
            AlbumListType type,
            int? size,
            int? offset,
            int? fromYear,
            int? toYear,
            string? genre,
            int? musicFolderId
            )
        {
            IQueryable<Album> query = dbContext.Albums
                .Include(album => album.Artist)
                .Include(album => album.Genre);

            if (type == AlbumListType.BY_YEAR && fromYear.HasValue && toYear.HasValue)
            {
                query = query
                    .Where(a => a.Year.HasValue &&
                        a.Year.Value >= int.Min(fromYear.Value, toYear.Value) &&
                        a.Year.Value <= int.Max(fromYear.Value, toYear.Value)   
                    );

                if (fromYear.Value <= toYear.Value)
                {
                    query = query.OrderBy(a => a.Year);
                }
                else
                {
                    query = query.OrderByDescending(a => a.Year);
                }
            }

            if (type == AlbumListType.BY_GENRE && !string.IsNullOrEmpty(genre))
            {
                query = query.Where(a => a.Genre != null && a.Genre.Name == genre);
            }

            if (type == AlbumListType.RANDOM)
            {
                query = query.OrderBy(a => EF.Functions.Random());
            }

            if (type == AlbumListType.NEWEST)
            {
                query = query.OrderByDescending(a => a.Created);
            }

            if (type == AlbumListType.ALPHABETICAL_BY_NAME)
            {
                query = query.OrderBy(a => a.Name);
            }

            if (type == AlbumListType.ALPHABETICAL_BY_ARTIST)
            {
                query = query.OrderBy(a => a.Artist == null ? "ZZZZZZ" : a.Artist.Name);
            }

            if (offset.HasValue)
            {
                query = query.Skip(offset.Value);
            }

            if (size.HasValue)
            {
                query = query.Take(size.Value);
            }
            
            var data = await query.ToListAsync();

            return data
                .Select(album => new AlbumList2Item()
                {
                    Id = album.Id.ToString(),
                    Name = album.Name,
                    Artist = album.Artist?.Name,
                    ArtistId = album.ArtistId?.ToString(),
                    CoverArt = album.CoverArtId?.ToString(),
                    SongCount = album.SongCount,
                    Duration = album.Duration,
                    PlayCount = album.PlayCount,
                    Created = album.Created,
                    Starred = album.Starred,
                    Year = album.Year,
                    Genre = album.Genre?.Name
                });
        }
    }
}