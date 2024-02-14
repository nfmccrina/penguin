using Microsoft.AspNetCore.Mvc;
using Penguin.Services;
using Penguin.Web.Services;

namespace Penguin.Web.Controllers
{
    public class ListsController : BasePenguinController
    {
        private readonly IAlbumList2Service albumList2Service;
        private readonly IAlbumList2ResponseBuilder albumList2ResponseBuilder;

        public ListsController(
            IAlbumList2Service albumList2Service,
            IAlbumList2ResponseBuilder albumList2ResponseBuilder)
        {
            this.albumList2Service = albumList2Service;
            this.albumList2ResponseBuilder = albumList2ResponseBuilder;
        }

        [Route("getAlbumList2.view")]
        [Route("getAlbumList2")]
        public async Task<IActionResult> AlbumList2(
            [FromQuery] string? f,
            [FromQuery] string type,
            [FromQuery] int? size,
            [FromQuery] int? offset,
            [FromQuery] int? fromYear,
            [FromQuery] int? toYear,
            [FromQuery] string? genre,
            [FromQuery] string? musicFolderId)
        {
            var data = await albumList2Service.GetAlbums(
                type,
                size,
                offset,
                fromYear,
                toYear,
                genre,
                musicFolderId
            );
            var response = albumList2ResponseBuilder.BuildAlbumList2Response(data);
            return SerializeResponse(f, response);
        }
    }
}