namespace Aimrank.Agones.Cluster.Infrastructure.Kubernetes.Agones
{
    internal class Fleet
    {
        public const string ResourceAddress = "apis/agones.dev/v1/namespaces/{0}/fleets/{1}";
        
        public FleetStatus Status { get; set; }

        internal class FleetStatus
        {
            public int AllocatedReplicas { get; set; }
            public int ReadyReplicas { get; set; }
            public int Replicas { get; set; }
            public int ReservedReplicas { get; set; }
        }
    }
}