using Aimrank.Agones.Cluster.Core.DTO;
using Aimrank.Agones.Cluster.Core.Validation;
using MediatR;
using System;

namespace Aimrank.Agones.Cluster.Core.Commands.CreateMatch
{
    public class CreateMatchCommand : IRequest<MatchDto>
    {
        [NotEmpty]
        public Guid ReservationId { get; }

        public CreateMatchCommand(Guid reservationId)
        {
            ReservationId = reservationId;
        }
    }
}