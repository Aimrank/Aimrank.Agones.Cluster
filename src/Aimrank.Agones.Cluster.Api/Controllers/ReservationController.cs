using Aimrank.Agones.Cluster.Core.Commands.CreateReservation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Aimrank.Agones.Cluster.Api.Controllers
{
    [Route(BasePath + "reservation")]
    public class ReservationController : BaseController
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}