using Penguin.Services.Data.Dtos;
using Penguin.Web.Dtos;
using AlbumDto = Penguin.Web.Dtos.Album;

namespace Penguin.Web.Services
{
    public interface IAlbumList2ResponseBuilder
    {
        Response BuildAlbumList2Response(IEnumerable<AlbumList2Item> data);
    }

    public class AlbumList2ResponseBuilder : IAlbumList2ResponseBuilder
    {
        private readonly IConfiguration configuration;

        public AlbumList2ResponseBuilder(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Response BuildAlbumList2Response(IEnumerable<AlbumList2Item> data)
        {
            var apiVersion = configuration["Api:ApiVersion"];
            var serverVersion = configuration["Api:ServerVersion"];
            var serverName = configuration["Api:ServerName"];

            var response = new Response(new SubsonicResponse(
                ResponseStatus.OK,
                apiVersion,
                serverName,
                serverVersion,
                albumList2: data.Select(item => new AlbumDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Artist = item.Artist,
                    ArtistId = item.ArtistId,
                    CoverArt = item.CoverArt,
                    SongCount = item.SongCount,
                    Duration = item.Duration,
                    PlayCount = item.PlayCount.HasValue ? item.PlayCount.Value : default,
                    Created = item.Created,
                    Starred = item.Starred.HasValue ? item.Starred.Value : default,
                    Year = item.Year.HasValue ? item.Year.Value : default,
                    Genre = item.Genre
                })
                )
            );

            return response;
        }
    }
}