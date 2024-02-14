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