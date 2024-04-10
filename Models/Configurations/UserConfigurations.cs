using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.UserRoles)
                .WithOne(o => o.User)
                .HasForeignKey(ol => ol.UserId);

            builder.HasMany(u => u.UserCassettes)
                .WithOne(o => o.User)
                .HasForeignKey(ol => ol.UserId);
        }
    }
}
