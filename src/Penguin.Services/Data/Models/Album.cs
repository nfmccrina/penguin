using System.Text.Json.Serialization;

namespace Penguin.Services.Data.Models
{
    public class Album
    {
        public Album()
        {
            Name = "";
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        public int? ArtistId { get; set; }
        public Artist? Artist { get; set; }
        public int? CoverArtId { get; set; }
        public CoverArt? CoverArt { get; set; }
        public int SongCount { get; set; }
        public int Duration { get; set; }
        public int? PlayCount { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Starred { get; set; }
        public int? Year { get; set; }
        public int? GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}