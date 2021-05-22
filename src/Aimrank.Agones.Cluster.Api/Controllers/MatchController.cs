using Aimrank.Agones.Cluster.Core.Commands.CreateMatch;
using Aimrank.Agones.Cluster.Core.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Aimrank.Agones.Cluster.Api.Controllers
{
    [Route(BasePath + "match")]
    public class MatchController : BaseController
    {
        private readonly IMediator _mediator;

        public MatchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<MatchDto>> Create(CreateMatchCommand command)
            => Ok(await _mediator.Send(command));
    }
}