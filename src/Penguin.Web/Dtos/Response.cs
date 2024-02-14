using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Penguin.Web.Dtos
{
    [DataContract()]
    public class Response : IExtensibleDataObject
    {
        public Response(SubsonicResponse subsonicResponse)
        {
            SubsonicResponse = subsonicResponse;
        }

        [DataMember(Name = "subsonic-reponse")]
        [JsonPropertyName("subsonic-response")]
        public SubsonicResponse SubsonicResponse { get; private set; }

        [JsonIgnore]
        public ExtensionDataObject? ExtensionData
        {
            get => extensionDataValue;
            set => extensionDataValue = value;
        }

        private ExtensionDataObject? extensionDataValue;
    }
}