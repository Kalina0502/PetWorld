using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetWorld.Infrastructure.Data;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddAplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<PetWorldDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddAplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.
                AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<PetWorldDbContext>();

            return services;
        }
    }
}