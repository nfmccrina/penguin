using System.Text.Json.Serialization;

namespace Penguin.Services.Data.Models
{
    public class Genre
    {
        public Genre()
        {
            Name = "";
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}