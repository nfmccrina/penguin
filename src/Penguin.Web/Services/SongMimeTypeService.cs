using Microsoft.AspNetCore.StaticFiles;

namespace Penguin.Web.Services
{
    public interface ISongMimeTypeService
    {
        string GetSongMimeTypeByPath(string path);
    }

    public class SongMimeTypeService : ISongMimeTypeService
    {
        public string GetSongMimeTypeByPath(string path)
        {
            var mimeTypeProvider = new FileExtensionContentTypeProvider();

            if (!mimeTypeProvider.TryGetContentType(path, out string? mimeType))
            {
                return "application/octet-stream";
            }

            return mimeType;
        }
    }
}