/*

Copyright (C) 2024 Nathan McCrina

This file is part of Penguin.
   
Penguin is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or (at
your option) any later version.

Penguin is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Penguin.  If not, see <https://www.gnu.org/licenses/>.

*/

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