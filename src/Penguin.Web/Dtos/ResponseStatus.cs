using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Penguin.Web.Services;

namespace Penguin.Web.Dtos
{
    [JsonConverter(typeof(ResponseStatusConverter))]
    public enum ResponseStatus
    {
        [XmlEnum(Name = "ok")]
        [EnumMember(Value = "ok")]
        OK,
        [XmlEnum(Name = "failed")]
        [EnumMember(Value = "failed")]
        FAILED
    }
}