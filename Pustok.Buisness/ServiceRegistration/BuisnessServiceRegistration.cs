using Microsoft.Extensions.DependencyInjection;
using Pustok.Buisness.Services.Abstractions;
using Pustok.Buisness.Services.Implementations;
using FluentValidation;
using Pustok.Core.Entities;
using Pustok.Buisness.Validators.ProductValidators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Pustok.Buisness.Dtos.TokenDtos;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Pustok.Buisness.ServiceRegistration
{
    public static class BuisnessServiceRegistration
    {
        public static IServiceCollection AddBuisnessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFluentValidationAutoValidation();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IProfessionService, ProfessionService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtService, JwtService>();

            services.AddValidatorsFromAssemblyContaining<EmployeeCreateDtoValidator>();

            services.AddAutoMapper(_ => { }, typeof(BuisnessServiceRegistration).Assembly);


            var jwtOptionDto = configuration.GetSection("JwtOptions").Get<JwtOptionDto>() ?? new();

            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,

                    ValidIssuer = jwtOptionDto.Issuer,
                    ValidAudience = jwtOptionDto.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptionDto.SecretKey)),
                    RoleClaimType = "Role"
                };

            });

            return services;
        }


    }
}
