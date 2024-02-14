namespace Penguin.Services.Exceptions
{
    public class CoverArtMissingException : Exception
    {
        public CoverArtMissingException(int id)
            : base($"Cover art {id} does not exist in the database.")
        {}
    }
}