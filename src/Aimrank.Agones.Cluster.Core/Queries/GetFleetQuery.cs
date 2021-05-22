using Aimrank.Agones.Cluster.Core.DTO;
using MediatR;

namespace Aimrank.Agones.Cluster.Core.Queries
{
    public class GetFleetQuery : IRequest<FleetDto>
    {
    }
}