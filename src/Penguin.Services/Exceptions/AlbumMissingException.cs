namespace Penguin.Services.Exceptions
{
    public class AlbumMissingException : Exception
    {
        public AlbumMissingException(int id)
            : base($"Album {id} does not exist in the database.")
        {}
    }
}