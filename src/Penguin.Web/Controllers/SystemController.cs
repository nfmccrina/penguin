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