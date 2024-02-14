namespace Penguin.Services.Exceptions
{
    public class SongMissingException : Exception
    {
        public SongMissingException(int id)
            : base($"Song {id} does not exist in the database.")
        {}
    }
}