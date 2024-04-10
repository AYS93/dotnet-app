using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Configurations
{
    public class RoleConfigurations : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(u => u.UserRoles)
                .WithOne(o => o.Role)
                .HasForeignKey(ol => ol.RoleId);

            builder.HasMany(u => u.RolePermissions)
                .WithOne(o => o.Role)
                .HasForeignKey(ol => ol.RoleId);
        }
    }
}
