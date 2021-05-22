using Aimrank.Agones.Cluster.Core.Entities;
using Aimrank.Agones.Cluster.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Aimrank.Agones.Cluster.Infrastructure.DataAccess.Repositories
{
    internal class SteamTokenRepository : ISteamTokenRepository
    {
        private readonly ClusterContext _context;

        public SteamTokenRepository(ClusterContext context)
        {
            _context = context;
        }

        public Task<SteamToken> GetByTokenAsync(string token) => _context.SteamTokens
            .FirstOrDefaultAsync(t => t.Token == token);

        public Task<SteamToken> GetByServerAsync(string server) => _context.SteamTokens
            .FirstOrDefaultAsync(t => t.Server == server);

        public Task<SteamToken> GetUnusedAsync() => _context.SteamTokens
            .FirstOrDefaultAsync(t => t.Server == null);

        public void Add(SteamToken steamToken) => _context.SteamTokens.Add(steamToken);

        public void Delete(SteamToken steamToken) => _context.SteamTokens.Remove(steamToken);
    }
}