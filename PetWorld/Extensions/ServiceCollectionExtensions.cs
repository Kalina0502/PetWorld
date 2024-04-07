﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetWorld.Core.Contracts.Adoption;
using PetWorld.Core.Services.Adoption;
using PetWorld.Infrastructure.Common;
using PetWorld.Infrastructure.Data;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAdoptionService, AdoptionService>();

            return services;
        }

        public static IServiceCollection AddAplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<PetWorldDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

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
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 8;
                })
                .AddEntityFrameworkStores<PetWorldDbContext>();

            return services;
        }
    }
}