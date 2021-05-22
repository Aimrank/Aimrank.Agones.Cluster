using Aimrank.Agones.Cluster.Core.DTO;
using System.Threading.Tasks;
using System;

namespace Aimrank.Agones.Cluster.Core.Services
{
    public interface IFleetService
    {
        Task<FleetDto> GetFleetAsync();
        Task<MatchDto> StartMatchAsync(Guid matchId, string map, string whitelist);
    }
}