using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Penguin.Services.Data.Dtos;

namespace Penguin.Web.Dtos
{
    [XmlRoot("subsonic-response")]
    public class SubsonicResponse
    {
        public SubsonicResponse()
        {
            Version = "1.0.0";
            ServerVersion = "0.0.1";
            Type = "Penguin";
        }

        public SubsonicResponse(
            ResponseStatus status,
            string? version,
            string? type,
            string? serverVersion,
            IEnumerable<GenreInfo>? genres = null,
            IEnumerable<Album>? albumList2 = null,
            AlbumWithSongs? album = null)
        {
            Status = status;
            Version = version ?? throw new ArgumentNullException(nameof(version));
            Type = type ?? throw new ArgumentNullException(nameof(type));
            ServerVersion = serverVersion ?? throw new ArgumentNullException(nameof(serverVersion));
            Genres = genres?.ToList();
            AlbumList2 = albumList2?.ToList();
            Album = album;
            OpenSubsonic = true;
        }

        [XmlAttribute(AttributeName = "status")]
        [JsonPropertyName("status")]
        public ResponseStatus Status { get; set;  }

        [XmlAttribute(AttributeName = "version")]
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [XmlAttribute(AttributeName = "type")]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "serverVersion")]
        [JsonPropertyName("serverVersion")]
        public string ServerVersion { get; set; }

        [XmlAttribute(AttributeName = "openSubsonic")]
        [JsonPropertyName("openSubsonic")]
        public bool OpenSubsonic { get; set; }

        [XmlArray(ElementName = "genres", IsNullable = false)]
        [XmlArrayItem(ElementName = "genre")]
        [JsonPropertyName("genres")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<GenreInfo>? Genres { get; set;}

        [XmlArray(ElementName = "albumList2", IsNullable = false)]
        [XmlArrayItem(ElementName = "album")]
        [JsonPropertyName("albumList2")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Album>? AlbumList2 { get; set; }

        [XmlElement(ElementName = "album", IsNullable = false)]
        [JsonPropertyName("album")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AlbumWithSongs? Album { get; set; }
    }
}