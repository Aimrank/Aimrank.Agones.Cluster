using Aimrank.Agones.Cluster.Core.Entities;
using System.Threading.Tasks;
using System;

namespace Aimrank.Agones.Cluster.Core.Repositories
{
    public interface IReservationRepository
    {
        Task<int> GetActiveCountAsync();
        Task<Reservation> GetAsync(Guid id);
        void Add(Reservation reservation);
    }
}