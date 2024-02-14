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