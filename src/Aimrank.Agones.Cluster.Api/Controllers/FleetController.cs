using Aimrank.Agones.Cluster.Core.DTO;
using Aimrank.Agones.Cluster.Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Aimrank.Agones.Cluster.Api.Controllers
{
    [Route(BasePath + "fleet")]
    public class FleetController : BaseController
    {
        private readonly IMediator _mediator;

        public FleetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<FleetDto>> GetFleet()
            => OkOrNotFound(await _mediator.Send(new GetFleetQuery()));
    }
}