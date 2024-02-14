using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Penguin.Web.Dtos
{
    public class GenreInfo
    {
        public GenreInfo()
        {
            Name = "";
        }

        public GenreInfo(string name, int songCount, int albumCount)
        {
            Name = name;
            SongCount = songCount;
            AlbumCount = albumCount;
        }
        
        [XmlAttribute(AttributeName = "songCount")]
        [JsonPropertyName("songCount")]
        public int SongCount { get; set;}

        [XmlAttribute(AttributeName = "albumCount")]
        [JsonPropertyName("albumCount")]
        public int AlbumCount { get; set; }

        [XmlText]
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}