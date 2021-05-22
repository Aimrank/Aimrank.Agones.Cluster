using Aimrank.Agones.Cluster.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Aimrank.Agones.Cluster.Infrastructure.DataAccess.Configurations
{
    internal class ReservationEntityTypeConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Map).IsRequired().HasMaxLength(64);
            builder.Property(r => r.Whitelist).IsRequired().HasMaxLength(512);
        }
    }
}