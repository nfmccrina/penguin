namespace Penguin.Services.Data.Dtos
{
    public class StreamData
    {
        public StreamData()
        {
            SongStream = FileStream.Null;
            FilePath = "";
        }

        public Stream SongStream { get; set; }
        public string FilePath { get; set; }
    }
}