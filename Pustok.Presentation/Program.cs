
using Pustok.Buisness.ServiceRegistration;
using Pustok.Buisness.Services.Abstractions;
using Pustok.Buisness.Services.Implementations;
using Pustok.DataAccess.ServiceRegistration;
using Pustok.Presentation.Middlewares;
using FluentValidation;
using FluentValidation.AspNetCore;
using Pustok.DataAccess.Abstractions;
using System.Threading.Tasks;

namespace Pustok.Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddBuisnessServices();
            builder.Services.AddDataAccessService(builder.Configuration);

            var app = builder.Build();

            var scope = app.Services.CreateScope();

            var initializer = scope.ServiceProvider.GetRequiredService<IContextInitializer>();
            await initializer.InitDatabaseAsync();

            app.UseMiddleware<GlobalExceptionHandler>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            await app.RunAsync();
        }
    }
}
