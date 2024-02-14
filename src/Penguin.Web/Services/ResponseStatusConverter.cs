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