using Aimrank.Agones.Cluster.Core.DTO;
using MediatR;
using System.Collections.Generic;

namespace Aimrank.Agones.Cluster.Core.Queries
{
    public class BrowseSteamTokensQuery : IRequest<IEnumerable<SteamTokenDto>>
    {
    }
}