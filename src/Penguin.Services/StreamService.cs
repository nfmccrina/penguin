using Penguin.Services.Data;
using Penguin.Services.Data.Dtos;

namespace Penguin.Services
{
    public interface IStreamService
    {
        Task<StreamData> GetSongForStreaming(int id);
    }

    public class StreamService : IStreamService
    {
        private readonly IPenguinRepository repository;

        public StreamService(IPenguinRepository repository)
        {
            this.repository = repository;
        }

        public async Task<StreamData> GetSongForStreaming(int id)
        {
            var songInfo = await repository.GetSongInfoForStreaming(id);

            string? path = null;

            if (string.IsNullOrEmpty(songInfo.LibraryPath))
            {
                path = songInfo.Path;
            }
            else
            {
                path = Path.Combine(songInfo.LibraryPath, songInfo.Path);
            }

            return new StreamData()
            {
                SongStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true),
                FilePath = path
            };
        }
    }
}