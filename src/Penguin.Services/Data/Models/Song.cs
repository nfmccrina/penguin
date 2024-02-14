using System.Text.Json.Serialization;

namespace Penguin.Services.Data.Models
{
    public class Song
    {
        public Song()
        {
            Name = "";
            Album = new Album();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? AlbumId { get; set; }
        public Album? Album { get; set; }
        public int? GenreId { get; set; }
        public Genre? Genre { get; set; }
        public int Duration { get; set; }
        public int? TrackNumber { get; set; }
        public DateTime Created { get; set; }
        public int? CoverArtId { get; set; }
        public CoverArt? CoverArt { get; set; }
        public string Path { get; set; }
        public int? LibraryId { get; set; }
        public Library? Library { get; set; }
    }
}