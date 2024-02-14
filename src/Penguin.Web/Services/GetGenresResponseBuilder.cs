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