using Aimrank.Agones.Cluster.Core.Repositories;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Aimrank.Agones.Cluster.Core.Commands.RemoveExpiredReservations
{
    internal class RemoveExpiredReservationsCommandHandler : IRequestHandler<RemoveExpiredReservationsCommand>
    {
        private readonly IReservationRepository _reservationRepository;

        public RemoveExpiredReservationsCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Unit> Handle(RemoveExpiredReservationsCommand request, CancellationToken cancellationToken)
        {
            await _reservationRepository.DeleteExpiredAsync();
            
            return Unit.Value;
        }
    }
}