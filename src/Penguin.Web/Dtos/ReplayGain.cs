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
    public class ReplayGain
    {
        public ReplayGain()
        {
            TrackGain = default;
            AlbumGain = default;
            TrackPeak = default;
            AlbumPeak = default;
            BaseGain = default;
            FallbackGain = default;
        }

        [XmlAttribute(AttributeName = "trackGain")]
        [JsonPropertyName("trackGain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int TrackGain { get; set; }
        [JsonIgnore]
        public bool TrackGainSpecified => TrackGain != default;

        [XmlAttribute(AttributeName = "albumGain")]
        [JsonPropertyName("albumGain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int AlbumGain { get; set; }
        [JsonIgnore]
        public bool AlbumGainSpecified => AlbumGain != default;

        [XmlAttribute(AttributeName = "trackPeak")]
        [JsonPropertyName("trackPeak")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int TrackPeak { get; set; }
        [JsonIgnore]
        public bool TrackPeakSpecified => TrackPeak != default;

        [XmlAttribute(AttributeName = "albumPeak")]
        [JsonPropertyName("albumPeak")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int AlbumPeak { get; set; }
        [JsonIgnore]
        public bool AlbumPeakSpecified => AlbumPeak != default;

        [XmlAttribute(AttributeName = "baseGain")]
        [JsonPropertyName("baseGain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int BaseGain { get; set; }
        [JsonIgnore]
        public bool BaseGainSpecified => TrackGain != default;

        [XmlAttribute(AttributeName = "fallbackGain")]
        [JsonPropertyName("fallbackGain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int FallbackGain { get; set; }
        [JsonIgnore]
        public bool FallbackGainSpecified => FallbackGain != default;
    }
}