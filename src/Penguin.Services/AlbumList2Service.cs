using Penguin.Services.Data;
using Penguin.Services.Data.Dtos;

namespace Penguin.Services
{
    public interface IAlbumList2Service
    {
        Task<IEnumerable<AlbumList2Item>> GetAlbums(
            string type,
            int? size,
            int? offset,
            int? fromYear,
            int? toYear,
            string? genre,
            string? musicFolderId);
    }

    public class AlbumList2Service : IAlbumList2Service
    {
        private readonly IPenguinRepository repository;

        public AlbumList2Service(IPenguinRepository repository)
        {
            this.repository = repository;
        }

        public Task<IEnumerable<AlbumList2Item>> GetAlbums(
            string type,
            int? size,
            int? offset,
            int? fromYear,
            int? toYear,
            string? genre,
            string? musicFolderId)
        {
            AlbumListType? albumListType = null;

            switch (type)
            {
                case "random":
                {
                    albumListType = AlbumListType.RANDOM;
                    break;
                }
                case "newest":
                {
                    albumListType = AlbumListType.NEWEST;
                    break;
                }
                case "highest":
                {
                    albumListType = AlbumListType.HIGHEST;
                    break;
                }
                case "frequent":
                {
                    albumListType = AlbumListType.FREQUENT;
                    break;
                }
                case "recent":
                {
                    albumListType = AlbumListType.RECENT;
                    break;
                }
                case "alphabeticalByName":
                {
                    albumListType = AlbumListType.ALPHABETICAL_BY_NAME;
                    break;
                }
                case "alphabeticalByArtis":
                {
                    albumListType = AlbumListType.ALPHABETICAL_BY_ARTIST;
                    break;
                }
                case "starred":
                {
                    albumListType = AlbumListType.STARRED;
                    break;
                }
                case "byYear":
                {
                    albumListType = AlbumListType.BY_YEAR;
                    break;
                }
                case "byGenre":
                {
                    albumListType = AlbumListType.BY_GENRE;
                    break;
                }
                default:
                {
                    throw new ArgumentException($"'{type}' is not a valid value for type.");
                }
            }
            return repository.ListAlbums2(
                albumListType.Value,
                size,
                offset,
                fromYear,
                toYear,
                genre,
                string.IsNullOrEmpty(musicFolderId) ? null : int.Parse(musicFolderId));
        }
    }
}