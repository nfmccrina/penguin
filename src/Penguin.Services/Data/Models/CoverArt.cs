namespace Penguin.Services.Data.Models
{
    public class CoverArt
    {
        public CoverArt()
        {
            Type = "";
            Data = [];
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public byte[] Data { get; set; }
    }
}