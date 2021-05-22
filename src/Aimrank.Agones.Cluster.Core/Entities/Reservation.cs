using System;

namespace Aimrank.Agones.Cluster.Core.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public string Map { get; set; }
        public string Whitelist { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool Started { get; set; }
    }
}