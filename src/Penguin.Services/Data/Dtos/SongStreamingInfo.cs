namespace Penguin.Services.Data.Dtos
{
    public class SongStreamingInfo
    {
        public SongStreamingInfo()
        {
            Path = "";
        }
        
        public string Path { get; set; }
        public string? LibraryPath { get; set; }
    }
}