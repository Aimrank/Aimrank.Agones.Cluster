using Aimrank.Agones.Cluster.Core.Entities;
using Aimrank.Agones.Cluster.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace Aimrank.Agones.Cluster.Infrastructure.DataAccess.Repositories
{
    internal class ReservationRepository : IReservationRepository
    {
        private readonly ClusterContext _context;

        public ReservationRepository(ClusterContext context)
        {
            _context = context;
        }

        public Task<int> GetActiveCountAsync() => _context.Reservations
            .CountAsync(r => !r.Started && r.ExpiresAt > DateTime.UtcNow);

        public Task<Reservation> GetAsync(Guid id) => _context.Reservations
            .FirstOrDefaultAsync(r => r.Id == id);

        public void Add(Reservation reservation) => _context.Add(reservation);

        public Task DeleteExpiredAsync() => _context.Database
            .ExecuteSqlRawAsync("DELETE FROM cluster.reservations WHERE expires_at <= timezone('utc', now());");
    }
}