
using Microsoft.AspNetCore.Mvc;
using Penguin.Services;
using Penguin.Services.Exceptions;
using Penguin.Web.Services;

namespace Penguin.Web.Controllers
{
    public class BrowsingController : BasePenguinController
    {
        private readonly IGetGenresService getGenresService;
        private readonly IGetGenresResponseBuilder responseBuilder;
        private readonly IGetAlbumService getAlbumService;
        private readonly IGetAlbumResponseBuilder getAlbumResponseBuilder;

        public BrowsingController(
            IGetGenresService getGenresService,
            IGetGenresResponseBuilder responseBuilder,
            IGetAlbumService getAlbumService,
            IGetAlbumResponseBuilder getAlbumResponseBuilder)
        {
            this.getGenresService = getGenresService;
            this.responseBuilder = responseBuilder;
            this.getAlbumService = getAlbumService;
            this.getAlbumResponseBuilder = getAlbumResponseBuilder;
        }

        [Route("getAlbum")]
        [Route("getAlbum.view")]
        public async Task<IActionResult> GetAlbum(
            [FromQuery] string? f,
            [FromQuery] string? id
        )
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            if (!int.TryParse(id, out int albumId))
            {
                return BadRequest();
            }

            Penguin.Services.Data.Dtos.Album? album = null;

            try
            {
                album = await getAlbumService.GetAlbum(albumId);
            }
            catch (AlbumMissingException)
            {
                return NotFound();
            }

            var response = getAlbumResponseBuilder.BuildGetAlbumResponse(album);

            return SerializeResponse(f, response);
        }

        [Route("getGenres")]
        [Route("getGenres.view")]
        public async Task<IActionResult> GetGenres([FromQuery] string? f)
        {
            var genreData = await getGenresService.GetGenres();

            var response = responseBuilder.BuildGetGenresResponse(genreData);

            return SerializeResponse(f, response);
        }
    }
}