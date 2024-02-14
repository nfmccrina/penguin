namespace Penguin.Services.Data.Dtos
{
    public class Album
    {
        public Album()
        {
            Name = "";
            Songs = new List<Song>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int SongCount => Songs.Count();
        public int Duration => Songs.Aggregate(0, (currentDuration, song) => currentDuration + song.Duration);
        public DateTime Created { get; set; }
        public IEnumerable<Song> Songs { get; set; }
        public string? Genre { get; set; }
        public int? CoverArtId { get; set; }
    }
}