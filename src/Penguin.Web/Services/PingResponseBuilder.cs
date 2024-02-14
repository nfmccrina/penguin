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

using Microsoft.Extensions.Configuration;
using Penguin.Web.Dtos;

namespace Penguin.Web.Services
{
    public interface IPingResponseBuilder
    {
        Response BuildPingResponse();
    }

    public class PingResponseBuilder : IPingResponseBuilder
    {
        private readonly IConfiguration configuration;

        public PingResponseBuilder(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Response BuildPingResponse()
        {
            var apiVersion = configuration["Api:ApiVersion"];
            var serverVersion = configuration["Api:ServerVersion"];
            var serverName = configuration["Api:ServerName"];

            return new Response(new SubsonicResponse(
                ResponseStatus.OK,
                apiVersion,
                serverName,
                serverVersion
                )
            );
        }
    }
}