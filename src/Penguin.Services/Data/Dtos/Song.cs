namespace Penguin.Services.Data.Dtos
{
    public class Song
    {
        public Song()
        {
            Name = "";
            Path = "";
            ReplayGain = new ReplayGain();
        }

        public int Id { get; set; }
        public int? AlbumId { get; set; }
        public int? CoverArtId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int? TrackNumber { get; set; }
        public ReplayGain ReplayGain { get; set; }
        public DateTime Created { get; set; }
        public string Path { get; set; }
    }
}