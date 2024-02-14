using Penguin.Services.Data;
using Penguin.Services.Data.Dtos;

namespace Penguin.Services
{
    public interface IGetCoverArtService
    {
        Task<CoverArt> GetCoverArt(int id);
    }

    public class GetCoverArtService : IGetCoverArtService
    {
        private readonly IPenguinRepository repository;

        public GetCoverArtService(IPenguinRepository repository)
        {
            this.repository = repository;
        }

        public Task<CoverArt> GetCoverArt(int id)
        {
            return repository.GetCoverArt(id);
        }
    }
}