namespace Aimrank.Agones.Cluster.Core.DTO
{
    public class FleetDto
    {
        public int AllocatedReplicas { get; set; }
        public int ReadyReplicas { get; set; }
        public int Replicas { get; set; }
        public int ReservedReplicas { get; set; }
    }
}