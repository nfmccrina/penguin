using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Penguin.Web.Dtos
{
    public class AlbumSongArtist
    {
        public AlbumSongArtist()
        {
            Id = "";
            Name = "";
        }

        [XmlAttribute(AttributeName = "id")]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}