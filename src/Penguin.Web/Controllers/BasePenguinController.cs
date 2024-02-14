using System.Text.Json;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Penguin.Web.Dtos;

namespace Penguin.Web.Controllers
{
    public class BasePenguinController : ControllerBase
    {
        protected ContentResult SerializeResponse(string? format, Response response)
        {
            var isJson = format == "json";

            if (isJson)
            {
                return new ContentResult()
                {
                    Content = JsonSerializer.Serialize(response),
                    ContentType = "application/json",
                    StatusCode = 200
                };
            }

            var xmlSerializer = new XmlSerializer(typeof(SubsonicResponse));
            using var memoryStream = new MemoryStream();
            xmlSerializer.Serialize(memoryStream, response.SubsonicResponse);
            memoryStream.Seek(0, SeekOrigin.Begin);
            var stringReader = new StreamReader(memoryStream);

            return new ContentResult()
            {
                Content = stringReader.ReadToEnd(),
                ContentType = "application/xml",
                StatusCode = 200
            };
        }
    }
}