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

using Penguin.Web.Dtos;
using DomainGenreInfo = Penguin.Services.Data.Dtos.GenreInfo;

namespace Penguin.Web.Services
{
    public interface IGetGenresResponseBuilder
    {
        Response BuildGetGenresResponse(IEnumerable<DomainGenreInfo> data);
    }

    public class GetGenresResponseBuilder : IGetGenresResponseBuilder
    {
        private readonly IConfiguration configuration;

        public GetGenresResponseBuilder(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Response BuildGetGenresResponse(IEnumerable<DomainGenreInfo> data)
        {
            var apiVersion = configuration["Api:ApiVersion"];
            var serverVersion = configuration["Api:ServerVersion"];
            var serverName = configuration["Api:ServerName"];

            var response = new Response(new SubsonicResponse(
                ResponseStatus.OK,
                apiVersion,
                serverName,
                serverVersion,
                genres: data.Select(g => new GenreInfo(g.Name, g.SongCount, g.AlbumCount))
                )
            );

            return response;
        }
    }

}