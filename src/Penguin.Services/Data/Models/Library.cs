namespace Penguin.Services.Data.Models
{
    public class Library
    {
        public Library()
        {
            Name = "";
            Path = "";
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}