using System;

namespace Aimrank.Agones.Cluster.Core.DTO
{
    public class MatchDto
    {
        public Guid MatchId { get; set; }
        public string Address { get; set; }
        public string Map { get; set; }
        public string Whitelist { get; set; }
    }
}