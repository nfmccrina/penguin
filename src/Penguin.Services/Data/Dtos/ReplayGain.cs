namespace Penguin.Services.Data.Dtos
{
    public class ReplayGain
    {
        public int? TrackGain { get; set; }
        public int? AlbumGain { get; set; }
        public int? TrackPeak { get; set; }
        public int? AlbumPeak { get; set; }
        public int? BaseGain { get; set; }
        public int? FallbackGain { get; set; }
    }
}