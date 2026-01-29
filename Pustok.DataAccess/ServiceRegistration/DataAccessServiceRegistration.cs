using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pustok.DataAccess.Context;
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

            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("Default"));          
            });

            return services;
        }

    }
}
