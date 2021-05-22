using Aimrank.Agones.Cluster.Core.Commands.RegisterPod;
using Aimrank.Agones.Cluster.Core.Commands.UnregisterPod;
using Aimrank.Agones.Cluster.Core.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Aimrank.Agones.Cluster.Api.Controllers
{
    [Route(BasePath + "pod")]
    public class PodController : BaseController
    {
        private readonly IMediator _mediator;

        public PodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<PodRegistrationDto>> Register(RegisterPodCommand command)
            => Ok(await _mediator.Send(command));

        [HttpPost("unregister")]
        public async Task<IActionResult> Unregister(UnregisterPodCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}