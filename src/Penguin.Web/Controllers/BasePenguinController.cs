/*

Copyright (C) 2024 Nathan McCrina

This file is part of Penguin.
   
Penguin is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or (at
your option) any later version.

Penguin is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Penguin.  If not, see <https://www.gnu.org/licenses/>.

*/

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