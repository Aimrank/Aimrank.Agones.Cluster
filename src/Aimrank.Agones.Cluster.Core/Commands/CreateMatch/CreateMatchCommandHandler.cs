using Aimrank.Agones.Cluster.Core.DTO;
using Aimrank.Agones.Cluster.Core.Exceptions;
using Aimrank.Agones.Cluster.Core.Repositories;
using Aimrank.Agones.Cluster.Core.Services;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Aimrank.Agones.Cluster.Core.Commands.CreateMatch
{
    internal class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, MatchDto>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IFleetService _fleetService;

        public CreateMatchCommandHandler(IReservationRepository reservationRepository, IFleetService fleetService)
        {
            _reservationRepository = reservationRepository;
            _fleetService = fleetService;
        }

        public async Task<MatchDto> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetAsync(request.ReservationId);
            if (reservation is null)
            {
                throw new ClusterException($"Reservation with ID '{request.ReservationId}' does not exist.");
            }

            if (reservation.ExpiresAt < DateTime.UtcNow)
            {
                throw new ClusterException($"Reservation with ID '{request.ReservationId}' already expired.");
            }

            reservation.Started = true;

            return await _fleetService.StartMatchAsync(reservation.Id, reservation.Map, reservation.Whitelist);
        }
    }
}