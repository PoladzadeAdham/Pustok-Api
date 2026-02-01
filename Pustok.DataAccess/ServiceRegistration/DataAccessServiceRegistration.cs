using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pustok.Core.Entities;
using Pustok.DataAccess.Abstractions;
using Pustok.DataAccess.Context;
using Pustok.DataAccess.DataInitializer;
using Pustok.DataAccess.Interceptors;
using Pustok.DataAccess.Repositories.Abstractions;
using Pustok.DataAccess.Repositories.Implementations;

namespace Pustok.DataAccess.ServiceRegistration
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IProfessionRepository, ProfessionRepository>();
            services.AddScoped<BaseAuditableInterceptor>();
            services.AddScoped<IContextInitializer, DbContextInitializer>();

            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("Default"));          
            });

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;

                options.User.RequireUniqueEmail = true;

            })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<AppDbContext>();


            return services;
        }

    }
}
