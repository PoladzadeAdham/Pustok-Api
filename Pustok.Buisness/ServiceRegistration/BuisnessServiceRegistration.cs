using Microsoft.Extensions.DependencyInjection;
using Pustok.Buisness.Services.Abstractions;
using Pustok.Buisness.Services.Implementations;

namespace Pustok.Buisness.ServiceRegistration
{
    public static class BuisnessServiceRegistration
    {
        public static IServiceCollection AddBuisnessServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IProfessionService, ProfessionService>();

            services.AddAutoMapper(_ => { }, typeof(BuisnessServiceRegistration).Assembly);

            return services;
        }


    }
}
