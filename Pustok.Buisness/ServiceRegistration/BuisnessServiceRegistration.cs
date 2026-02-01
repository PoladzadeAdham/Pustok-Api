using Microsoft.Extensions.DependencyInjection;
using Pustok.Buisness.Services.Abstractions;
using Pustok.Buisness.Services.Implementations;
using FluentValidation;
using Pustok.Core.Entities;
using Pustok.Buisness.Validators.ProductValidators;
using FluentValidation.AspNetCore;

namespace Pustok.Buisness.ServiceRegistration
{
    public static class BuisnessServiceRegistration
    {
        public static IServiceCollection AddBuisnessServices(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IProfessionService, ProfessionService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddValidatorsFromAssemblyContaining<EmployeeCreateDtoValidator>();

            services.AddAutoMapper(_ => { }, typeof(BuisnessServiceRegistration).Assembly);

            return services;
        }


    }
}
