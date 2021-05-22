using Aimrank.Agones.Cluster.Core.Validation;
using MediatR;
using System;

namespace Aimrank.Agones.Cluster.Core.Commands.CreateReservation
{
    public class CreateReservationCommand : IRequest
    {
        [NotEmpty]
        public Guid Id { get; }
        
        [NotEmpty]
        public string Map { get; }
        
        [NotEmpty]
        public string Whitelist { get; }

        [NotEmpty]
        public DateTime ExpiresAt { get; }

        public CreateReservationCommand(Guid id, string map, string whitelist, DateTime expiresAt)
        {
            Id = id;
            Map = map;
            Whitelist = whitelist;
            ExpiresAt = expiresAt;
        }
    }
}