namespace Penguin.Services.Data.Dtos
{
    public class AlbumList2Item
    {
        public AlbumList2Item()
        {
            Id = "";
            Name = "";
        }
        
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Artist { get; set; }
        public string? ArtistId { get; set; }
        public string? CoverArt { get; set; }
        public int SongCount { get; set; }
        public int Duration { get; set; }
        public int? PlayCount { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Starred { get; set; }
        public int? Year { get; set; }
        public string? Genre { get; set; }
    }
}