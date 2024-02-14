namespace Penguin.Services.Data.Dtos
{
    public class CoverArt
    {
        public CoverArt()
        {
            Type = "";
            Data = [];
        }

        public string Type { get; set; }
        public byte[] Data { get; set; }
    }
}