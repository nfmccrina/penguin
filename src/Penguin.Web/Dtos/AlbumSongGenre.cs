using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Penguin.Web.Dtos
{
    public class AlbumSongGenre
    {
        public AlbumSongGenre()
        {
            Name = "";
        }

        [XmlAttribute(AttributeName = "name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}