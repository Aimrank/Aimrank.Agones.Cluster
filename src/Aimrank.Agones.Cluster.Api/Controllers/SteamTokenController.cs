using Aimrank.Agones.Cluster.Core.Commands.CreateSteamToken;
using Aimrank.Agones.Cluster.Core.Commands.DeleteSteamToken;
using Aimrank.Agones.Cluster.Core.DTO;
using Aimrank.Agones.Cluster.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aimrank.Agones.Cluster.Api.Controllers
{
    [Route(BasePath + "steam-token")]
    public class SteamTokenController : BaseController
    {
        private readonly IMediator _mediator;

        public SteamTokenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SteamTokenDto>>> Browse() =>
            Ok(await _mediator.Send(new BrowseSteamTokensQuery()));

        [HttpPost]
        public async Task<IActionResult> Create(CreateSteamTokenCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        
        [HttpDelete("{token}")]
        public async Task<IActionResult> Delete(string token)
        {
            await _mediator.Send(new DeleteSteamTokenCommand(token));
            return NoContent();
        }
    }
}