using Aimrank.Agones.Cluster.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aimrank.Agones.Cluster.Infrastructure.DataAccess
{
    internal class ClusterContext : DbContext
    {
        public DbSet<SteamToken> SteamTokens { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        
        public ClusterContext(DbContextOptions<ClusterContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("cluster");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}