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