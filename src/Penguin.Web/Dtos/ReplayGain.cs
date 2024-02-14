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