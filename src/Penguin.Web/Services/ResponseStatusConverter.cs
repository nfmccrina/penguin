using System.Text.Json;
using System.Text.Json.Serialization;
using Penguin.Web.Dtos;

namespace Penguin.Web.Services
{
    class ResponseStatusConverter : JsonConverter<ResponseStatus>
    {
        public override ResponseStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, ResponseStatus value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"{(value == ResponseStatus.OK ? "ok" : "failed")}");
        }
    }
}