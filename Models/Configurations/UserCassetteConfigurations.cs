using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Configurations
{
    public class UserCassetteConfigurations : IEntityTypeConfiguration<UserCassette>
    {
        public void Configure(EntityTypeBuilder<UserCassette> builder)
        {

        }
    }
}
