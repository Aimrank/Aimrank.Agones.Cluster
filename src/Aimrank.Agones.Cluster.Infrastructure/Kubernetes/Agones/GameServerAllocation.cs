using System.Collections.Generic;

namespace Aimrank.Agones.Cluster.Infrastructure.Kubernetes.Agones
{
    internal class GameServerAllocation
    {
        public const string ResourceAddress = "apis/allocation.agones.dev/v1/namespaces/{0}/gameserverallocations";
        public const string AgonesMap = "agones.dev/sdk-map";
        public const string AgonesMatchId = "agones.dev/sdk-matchId";
        public const string AgonesWhitelist = "agones.dev/sdk-whitelist";
        
        public string ApiVersion => "allocation.agones.dev/v1";
        public string Kind => nameof(GameServerAllocation);
        
        public AllocationSpec Spec { get; set; }
        public AllocationStatus Status { get; set; }

        public static GameServerAllocation Create(
            Dictionary<string, string> matchLabels,
            Dictionary<string, string> labels,
            Dictionary<string, string> annotations)
        {
            return new GameServerAllocation
            {
                Spec = new AllocationSpec
                {
                    Required = new AllocationSpec.RequiredField {MatchLabels = matchLabels},
                    Metadata = new AllocationSpec.MetadataField
                    {
                        Labels = labels,
                        Annotations = annotations
                    }
                }
            };
        }

        internal class AllocationSpec
        {
            public RequiredField Required { get; set; }
            public MetadataField Metadata { get; set; }
            
            internal class RequiredField
            {
                public Dictionary<string, string> MatchLabels { get; set; } = new();
            }

            internal class MetadataField
            {
                public Dictionary<string, string> Labels { get; set; } = new();
                public Dictionary<string, string> Annotations { get; set; } = new();
            }
        }
        
        internal class AllocationStatus
        {
            public string State { get; set; }
            public string Address { get; set; }
            public string NodeName { get; set; }
            public string GameServerName { get; set; }
            public IEnumerable<ServerPort> Ports { get; set; }
        }
        
        internal class ServerPort
        {
            public string Name { get; set; }
            public int Port { get; set; }
        }
    }
}