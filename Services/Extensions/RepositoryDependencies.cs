using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Extensions;
using SharedRepository;

namespace Services.Extensions
{
    public static class RepositoryDependencies
    {
        public static void ConfigureRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICassetteRepository, CassetteRepository>();
            services.AddScoped<IUserCassetteRepository, UserCassetteRepository>();

            services.ConfigureModel(connectionString);
        }
    }
}
