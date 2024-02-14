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
using System.Xml.Serialization;

namespace Penguin.Web.Dtos
{
    public class GenreInfo
    {
        public GenreInfo()
        {
            Name = "";
        }

        public GenreInfo(string name, int songCount, int albumCount)
        {
            Name = name;
            SongCount = songCount;
            AlbumCount = albumCount;
        }
        
        [XmlAttribute(AttributeName = "songCount")]
        [JsonPropertyName("songCount")]
        public int SongCount { get; set;}

        [XmlAttribute(AttributeName = "albumCount")]
        [JsonPropertyName("albumCount")]
        public int AlbumCount { get; set; }

        [XmlText]
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}