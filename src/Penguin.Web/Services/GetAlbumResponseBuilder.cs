using Penguin.Web.Dtos;

namespace Penguin.Web.Services
{
    public interface IGetAlbumResponseBuilder
    {
        Response BuildGetAlbumResponse(Penguin.Services.Data.Dtos.Album album);
    }

    public class GetAlbumResponseBuilder : IGetAlbumResponseBuilder
    {
        private readonly IConfiguration configuration;

        public GetAlbumResponseBuilder(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Response BuildGetAlbumResponse(Penguin.Services.Data.Dtos.Album album)
        {
            var apiVersion = configuration["Api:ApiVersion"];
            var serverVersion = configuration["Api:ServerVersion"];
            var serverName = configuration["Api:ServerName"];

            var response = new Response(new SubsonicResponse(
                ResponseStatus.OK,
                apiVersion,
                serverName,
                serverVersion,
                album: new AlbumWithSongs()
                {
                    Id = album.Id.ToString(),
                    Name = album.Name,
                    Artist = null,
                    ArtistId = null,
                    CoverArt = album.CoverArtId?.ToString(),
                    SongCount = album.SongCount,
                    Duration = album.Duration,
                    PlayCount = default,
                    Created = album.Created,
                    Starred = default,
                    Year = default,
                    Genre = album.Genre,
                    Songs = album.Songs.Select(s => new AlbumSong()
                    {
                        Id = s.Id.ToString(),
                        Parent = s.AlbumId?.ToString(),
                        Title = s.Name,
                        Album = null,
                        Artist = null,
                        Track = s.TrackNumber.HasValue ? s.TrackNumber.Value : default,
                        Year = default,
                        Genre = null,
                        CoverArt = s.CoverArtId?.ToString(),
                        Size = default,
                        ContentType = null,
                        Suffix = null,
                        TranscodedContentType = null,
                        TranscodedSuffix = null,
                        Duration = s.Duration,
                        Bitrate = default,
                        Path = null,
                        UserRating = default,
                        AverageRating = default,
                        PlayCount = default,
                        DiscNumber = default,
                        Created = s.Created,
                        Starred = default,
                        AlbumId = s.AlbumId?.ToString(),
                        ArtistId = null,
                        Type = null,
                        MediaType = null,
                        BookmarkPosition = default,
                        OriginalWidth = default,
                        OriginalHeight = default,
                        Played = default,
                        BPM = default,
                        Comment = null,
                        SortName = null,
                        MusicBrainzId = null,
                        Genres = null,
                        Artists = null,
                        DisplayArtist = null,
                        AlbumArtists = null,
                        DisplayAlbumArtist = null,
                        Contributors = null,
                        DisplayComposer = null,
                        Moods = null,
                        ReplayGain = new ReplayGain()
                        {
                            TrackGain = s.ReplayGain.TrackGain.HasValue ? s.ReplayGain.TrackGain.Value : default,
                            AlbumGain = s.ReplayGain.AlbumGain.HasValue ? s.ReplayGain.AlbumGain.Value : default,
                            TrackPeak = s.ReplayGain.TrackPeak.HasValue ? s.ReplayGain.TrackPeak.Value : default,
                            AlbumPeak = s.ReplayGain.AlbumPeak.HasValue ? s.ReplayGain.AlbumPeak.Value : default,
                            BaseGain = s.ReplayGain.BaseGain.HasValue ? s.ReplayGain.BaseGain.Value : default,
                            FallbackGain = s.ReplayGain.FallbackGain.HasValue ? s.ReplayGain.FallbackGain.Value : default
                        }
                    }).ToList()
                }));

            return response;
        }
    }
}