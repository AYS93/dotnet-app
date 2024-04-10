using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Configurations
{
    public class CassetteConfigurations : IEntityTypeConfiguration<Cassette>
    {
        public void Configure(EntityTypeBuilder<Cassette> builder)
        {

            builder.HasMany(u => u.UserCassettes)
                .WithOne(o => o.Cassette)
                .HasForeignKey(ol => ol.CassetteId);

            builder.Property(c => c.Quantity)
                .HasDefaultValue(0);
        }
    }
}
