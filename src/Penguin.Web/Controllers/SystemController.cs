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
using Penguin.Web.Services;

namespace Penguin.Web.Controllers
{
    public class SystemController : BasePenguinController
    {
        private readonly IPingResponseBuilder pingResponseBuilder;

        public SystemController(IPingResponseBuilder pingResponseBuilder)
        {
            this.pingResponseBuilder = pingResponseBuilder;
        }

        [Route("ping.view")]
        [Route("ping")]
        public async Task<IActionResult> Ping(
            [FromQuery] string f
        )
        {
            await Task.CompletedTask;
            var response = pingResponseBuilder.BuildPingResponse();

            return SerializeResponse(f, response);
        }
    }
}