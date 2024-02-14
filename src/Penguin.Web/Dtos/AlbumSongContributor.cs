using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Penguin.Web.Dtos
{
    public class AlbumSongContributor
    {
        public AlbumSongContributor()
        {
            Role = "";
            Artist = new ContributorArtist();
        }

        [XmlAttribute(AttributeName = "role")]
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [XmlAttribute(AttributeName = "subRole")]
        [JsonPropertyName("subRole")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SubRole { get; set; }
        [JsonIgnore]
        public bool SubRoleSpecified => !string.IsNullOrEmpty(SubRole);

        [XmlElement(ElementName = "artist")]
        [JsonPropertyName("artist")]
        public ContributorArtist Artist { get; set; }
    }
}