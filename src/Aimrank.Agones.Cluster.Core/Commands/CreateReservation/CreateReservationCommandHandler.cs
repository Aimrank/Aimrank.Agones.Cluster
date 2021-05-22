using Aimrank.Agones.Cluster.Core.Entities;
using Aimrank.Agones.Cluster.Core.Exceptions;
using Aimrank.Agones.Cluster.Core.Repositories;
using Aimrank.Agones.Cluster.Core.Services;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Aimrank.Agones.Cluster.Core.Commands.CreateReservation
{
    internal class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IFleetService _fleetService;

        public CreateReservationCommandHandler(IReservationRepository reservationRepository, IFleetService fleetService)
        {
            _reservationRepository = reservationRepository;
            _fleetService = fleetService;
        }

        public async Task<Unit> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var activeReservations = await _reservationRepository.GetActiveCountAsync();
            
            var fleet = await _fleetService.GetFleetAsync();
            if (fleet is null || fleet.ReadyReplicas - activeReservations <= 0)
            {
                throw new ClusterException("Fleet doesn't have any ready server.");
            }

            var reservation = new Reservation
            {
                Id = request.Id,
                Map = request.Map,
                Whitelist = request.Whitelist,
                ExpiresAt = request.ExpiresAt
            };

            _reservationRepository.Add(reservation);
            
            return Unit.Value;
        }
    }
}