using Aimrank.Agones.Cluster.Core.DTO;
using Aimrank.Agones.Cluster.Core.Exceptions;
using Aimrank.Agones.Cluster.Core.Services;
using Aimrank.Agones.Cluster.Infrastructure.Kubernetes.Agones;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using System;
using k8s;

namespace Aimrank.Agones.Cluster.Infrastructure.Kubernetes
{
    internal class FleetService : IFleetService
    {
        private readonly k8s.Kubernetes _kubernetes = new(KubernetesClientConfiguration.InClusterConfig());
        private readonly FleetSettings _fleetSettings;

        public FleetService(IOptions<FleetSettings> fleetSettings)
        {
            _fleetSettings = fleetSettings.Value;
        }

        public async Task<FleetDto> GetFleetAsync()
        {
            var fleet = await _kubernetes.GetNamespacedFleetAsync(_fleetSettings.Namespace, _fleetSettings.FleetName);
            if (fleet is null)
            {
                return null;
            }
            
            return new FleetDto
            {
                Replicas = fleet.Status.Replicas,
                AllocatedReplicas = fleet.Status.AllocatedReplicas,
                ReadyReplicas = fleet.Status.ReadyReplicas,
                ReservedReplicas = fleet.Status.ReservedReplicas
            };
        }

        public async Task<MatchDto> StartMatchAsync(Guid matchId, string map, string whitelist)
        {
            var allocation = await _kubernetes.CreateNamespacedGameServerAllocationAsync(_fleetSettings.Namespace, matchId, map, whitelist);
            if (allocation is null)
            {
                throw new ClusterException("Failed to allocate game server.");
            }

            if (allocation.Status.State != "Allocated")
            {
                throw new ClusterException($"Failed to allocate game server: State = {allocation.Status.State}");
            }
            
            var serverPort = allocation.Status.Ports
                .FirstOrDefault(p => p.Name.StartsWith("srcds"))?.Port;
                    
            return new MatchDto
            {
                MatchId = matchId,
                Address = $"{allocation.Status.Address}:{serverPort}",
                Map = map,
                Whitelist = whitelist
            };
        }
    }
}