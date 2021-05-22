using Aimrank.Agones.Cluster.Core.DTO;
using Aimrank.Agones.Cluster.Core.Queries;
using Aimrank.Agones.Cluster.Core.Repositories;
using Aimrank.Agones.Cluster.Core.Services;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Aimrank.Agones.Cluster.Infrastructure.Queries
{
    internal class GetFleetQueryHandler : IRequestHandler<GetFleetQuery, FleetDto>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IFleetService _fleetService;

        public GetFleetQueryHandler(IReservationRepository reservationRepository, IFleetService fleetService)
        {
            _reservationRepository = reservationRepository;
            _fleetService = fleetService;
        }

        public async Task<FleetDto> Handle(GetFleetQuery request, CancellationToken cancellationToken)
        {
            var fleet = await _fleetService.GetFleetAsync();
            if (fleet is null)
            {
                return null;
            }

            var activeReservations = await _reservationRepository.GetActiveCountAsync();

            fleet.ReadyReplicas -= activeReservations;
            fleet.AllocatedReplicas += activeReservations;

            return fleet;
        }
    }
}