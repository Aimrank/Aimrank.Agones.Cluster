using Aimrank.Agones.Cluster.Core.DTO;
using Aimrank.Agones.Cluster.Core.Queries;
using Aimrank.Agones.Cluster.Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Aimrank.Agones.Cluster.Infrastructure.Queries
{
    internal class BrowseSteamTokensQueryHandler : IRequestHandler<BrowseSteamTokensQuery, IEnumerable<SteamTokenDto>>
    {
        private readonly ClusterContext _context;

        public BrowseSteamTokensQueryHandler(ClusterContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SteamTokenDto>> Handle(BrowseSteamTokensQuery request,
            CancellationToken cancellationToken)
            => await _context.SteamTokens.AsNoTracking()
                .Select(t => new SteamTokenDto
                {
                    Token = t.Token,
                    IsUsed = t.Server != null
                }).ToListAsync(cancellationToken);
    }
}