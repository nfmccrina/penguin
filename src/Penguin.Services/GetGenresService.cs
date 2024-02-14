using Penguin.Services.Data;
using Penguin.Services.Data.Dtos;

namespace Penguin.Services
{
    public interface IGetGenresService
    {
        Task<IEnumerable<GenreInfo>> GetGenres();
    }

    public class GetGenresService : IGetGenresService
    {
        private readonly IPenguinRepository repository;

        public GetGenresService(IPenguinRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<GenreInfo>> GetGenres()
        {
            return await repository.GetGenres();
        }
    }
}