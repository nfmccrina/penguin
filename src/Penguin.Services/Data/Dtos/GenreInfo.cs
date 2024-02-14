namespace Penguin.Services.Data.Dtos;

public class GenreInfo
{
    public GenreInfo()
    {
        Name = "";
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int SongCount { get; set; }
    public int AlbumCount { get; set; }
}
