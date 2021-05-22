using Aimrank.Agones.Cluster.Core.Entities;
using System.Threading.Tasks;

namespace Aimrank.Agones.Cluster.Core.Repositories
{
    public interface ISteamTokenRepository
    {
        Task<SteamToken> GetByTokenAsync(string token);
        Task<SteamToken> GetByServerAsync(string server);
        Task<SteamToken> GetUnusedAsync();
        void Add(SteamToken steamToken);
        void Delete(SteamToken steamToken);
    }
}