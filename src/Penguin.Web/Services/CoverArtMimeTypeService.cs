using Microsoft.AspNetCore.StaticFiles;

namespace Penguin.Web.Services
{
    public interface ICoverArtMimeTypeService
    {
        string GetCoverArtMimeTypeByExtension(string extension);
    }

    public class CoverArtMimeTypeService : ICoverArtMimeTypeService
    {
        public string GetCoverArtMimeTypeByExtension(string extension)
        {
            var mimeTypeProvider = new FileExtensionContentTypeProvider();

            if (!mimeTypeProvider.TryGetContentType($"foo.{extension}", out string? mimeType))
            {
                return "application/octet-stream";
            }

            return mimeType;
        }
    }
}