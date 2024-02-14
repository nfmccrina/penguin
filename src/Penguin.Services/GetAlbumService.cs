using Penguin.Services.Data;
using Penguin.Services.Data.Dtos;

namespace Penguin.Services
{
    public interface IGetAlbumService
    {
        Task<Album> GetAlbum(int id);
    }

    public class GetAlbumService : IGetAlbumService
    {
        private readonly IPenguinRepository repository;

        public GetAlbumService(IPenguinRepository repository)
        {
            this.repository = repository;
        }

        public Task<Album> GetAlbum(int id)
        {
            return this.repository.GetAlbumWithSongs(id);
        }
    }
}