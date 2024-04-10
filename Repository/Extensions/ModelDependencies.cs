using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models;

namespace Repository.Extensions
{
    public static class ModelDependencies
    {
        public static void ConfigureModel(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EntityContext>(
                options => options.UseNpgsql(connectionString));
        }
    }
}
