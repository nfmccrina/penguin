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
using Penguin.Services.Data.Dtos;
using Penguin.Services.Exceptions;
using Penguin.Web.Services;

namespace Penguin.Web.Controllers
{
    public class MediaRetrievalController : BasePenguinController
    {
        private readonly IGetCoverArtService coverArtService;
        private readonly ICoverArtMimeTypeService mimeTypeService;
        private readonly IStreamService streamService;
        private readonly ISongMimeTypeService songMimeTypeService;

        public MediaRetrievalController(
            IGetCoverArtService coverArtService,
            ICoverArtMimeTypeService mimeTypeService,
            IStreamService streamService,
            ISongMimeTypeService songMimeTypeService
        )
        {
            this.coverArtService = coverArtService;
            this.mimeTypeService = mimeTypeService;
            this.streamService = streamService;
            this.songMimeTypeService = songMimeTypeService;
        }

        [Route("getCoverArt")]
        [Route("getCoverArt.view")]
        public async Task<IActionResult> GetCoverArt([FromQuery] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            if (!int.TryParse(id, out int coverArtId))
            {
                return BadRequest();
            }

            CoverArt? coverArtInfo;

            try
            {
                coverArtInfo = await coverArtService.GetCoverArt(coverArtId);
            }
            catch (CoverArtMissingException)
            {
                return NotFound();
            }
            var mimeType = mimeTypeService.GetCoverArtMimeTypeByExtension(coverArtInfo.Type);

            return new FileContentResult(coverArtInfo.Data, mimeType);
        }

        [Route("stream.view")]
        [Route("stream")]
        public async Task<IActionResult> Stream([FromQuery] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            if (!int.TryParse(id, out int songId))
            {
                return BadRequest();
            }

            StreamData? streamData;
            
            try
            {
                streamData = await streamService.GetSongForStreaming(songId);
            }
            catch (SongMissingException)
            {
                return NotFound();
            }

            var fileStream = streamData.SongStream;
            var mimeType = songMimeTypeService.GetSongMimeTypeByPath(streamData.FilePath);

            HttpContext.Response.RegisterForDispose(fileStream);

            return new FileStreamResult(fileStream, mimeType);
        }
    }
}