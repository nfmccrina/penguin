namespace Penguin.Services.Data.Models
{
    public class Artist
    {
        public Artist()
        {
            Name = "";
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CoverArtId { get; set; }
        public CoverArt? CoverArt { get; set; }
    }
}