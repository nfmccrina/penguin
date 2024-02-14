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
    public class AlbumWithSongs
    {
        public AlbumWithSongs()
        {
            Id = "";
            Name = "";
        }

        [XmlAttribute(AttributeName = "id")]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "artist")]
        [JsonPropertyName("artist")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Artist { get; set; }
        [JsonIgnore]
        public bool ArtistSpecified => !string.IsNullOrEmpty(Artist);

        [XmlAttribute(AttributeName = "artistId")]
        [JsonPropertyName("artistId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ArtistId { get; set; }
        [JsonIgnore]
        public bool ArtistIdSpecified => !string.IsNullOrEmpty(ArtistId);

        [XmlAttribute(AttributeName = "coverArt")]
        [JsonPropertyName("coverArt")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CoverArt { get; set; }
        [JsonIgnore]
        public bool CoverArtSpecified => !string.IsNullOrEmpty(CoverArt);

        [XmlAttribute(AttributeName = "songCount")]
        [JsonPropertyName("songCount")]
        public int SongCount { get; set; }

        [XmlAttribute(AttributeName = "duration")]
        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [XmlAttribute(AttributeName = "playCount")]
        [JsonPropertyName("playCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int PlayCount { get; set; }
        [JsonIgnore]
        public bool PlayCountSpecified => PlayCount != default;

        [XmlAttribute(AttributeName = "created")]
        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [XmlAttribute(AttributeName = "starred")]
        [JsonPropertyName("starred")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime Starred { get; set; }
        [JsonIgnore]
        public bool StarredSpecified => Starred != default;

        [XmlAttribute(AttributeName = "year")]
        [JsonPropertyName("year")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int Year { get; set; }
        [JsonIgnore]
        public bool YearSpecified => Year != default;

        [XmlAttribute(AttributeName = "genre")]
        [JsonPropertyName("genre")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Genre { get; set; }
        [JsonIgnore]
        public bool GenreSpecified => string.IsNullOrEmpty(Genre);

        [XmlElement(ElementName = "song")]
        public List<AlbumSong>? Songs { get; set; }
    }
}