using Microsoft.EntityFrameworkCore;
using Models.Configurations;
using Models.Models;

namespace Models
{
    public class EntityContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserCassette> UserCassettes { get; set; }
        public DbSet<Cassette> Cassettes { get; set; }
        public DbSet<RfToken> Tokens { get; set; }

        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CassetteConfigurations());
            modelBuilder.ApplyConfiguration(new PermissionConfigurations());
            modelBuilder.ApplyConfiguration(new RoleConfigurations());
            modelBuilder.ApplyConfiguration(new RolePermissionConfigurations());
            modelBuilder.ApplyConfiguration(new UserCassetteConfigurations());
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new UserRoleConfigurations());

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var permissions = new List<Permission>
            {
                new Permission { Id = 1, Name = "canView" },
                new Permission { Id = 2, Name = "canRentMovies" },
                new Permission { Id = 3, Name = "canManageUser" },
                new Permission { Id = 4, Name = "canManageCassetts" }
            };
            modelBuilder.Entity<Permission>().HasData(permissions);

            var roles = new List<Role>
            {
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "User" },
                new Role { Id = 3, Name = "Guest" }

            };
            modelBuilder.Entity<Role>().HasData(roles);

            var rolePermissions = new List<RolePermission>
            {
                new RolePermission { RoleId = 1, PermissionId = 1 },
                new RolePermission { RoleId = 1, PermissionId = 2 },
                new RolePermission { RoleId = 2, PermissionId = 1 },
                new RolePermission { RoleId = 2, PermissionId = 2 },
                new RolePermission { RoleId = 2, PermissionId = 3 },
                new RolePermission { RoleId = 2, PermissionId = 4 },
                new RolePermission { RoleId = 3, PermissionId = 1 },
            };
            modelBuilder.Entity<RolePermission>().HasData(rolePermissions);

            var users = new List<User>
            {
                new User { Id = 1, FirstName = "Admin", LastName = "Admin", Email = "admin@admin.com", Password = "Admin123", },
                new User { Id = 2, FirstName = "User", LastName = "User", Email = "user@user.com", Password = "User123",  },
                new User { Id = 3, FirstName = "Guest", LastName = "Guest", Email = "guest@guest.com", Password = "Guest123",  },

            };
            modelBuilder.Entity<User>().HasData(users);


            var userRoles = new List<UserRole>
            {
                new UserRole { UserId = 1, RoleId = 1},
                new UserRole { UserId = 2, RoleId = 2},
                new UserRole { UserId = 3, RoleId = 3},

            };
            modelBuilder.Entity<UserRole>().HasData(userRoles);

            var cassettes = new List<Cassette>
            {
                new Cassette { Id = 1, Name = "Taxi", Quantity = 3},
                new Cassette { Id = 2, Name = "Pulp Finction", Quantity = 3},
                new Cassette { Id = 3, Name = "Sleepless in Seattle", Quantity = 3},
                new Cassette { Id = 4, Name = "Ghost", Quantity = 4},
                new Cassette { Id = 5, Name = "Romancing the Stone", Quantity = 3},
                new Cassette { Id = 6, Name = "Grease", Quantity = 3},
                new Cassette { Id = 7, Name = "The Godfather", Quantity = 3},
                new Cassette { Id = 8, Name = "Scarface", Quantity = 1}
            };
            modelBuilder.Entity<Cassette>().HasData(cassettes);

            var userCassette = new List<UserCassette>
            {
                new UserCassette{ Id = 1, UserId = 1, CassetteId = 8, TakeDate = DateTime.UtcNow, ReturnDate = null},
                new UserCassette{ Id = 2, UserId = 2, CassetteId = 1, TakeDate = DateTime.UtcNow, ReturnDate = null},
                new UserCassette{ Id = 3, UserId = 2, CassetteId = 3, TakeDate = DateTime.UtcNow, ReturnDate = null},
                new UserCassette{ Id = 4, UserId = 2, CassetteId = 5, TakeDate = DateTime.UtcNow, ReturnDate = null},
            };
            modelBuilder.Entity<UserCassette>().HasData(userCassette);
        }
    }
}
