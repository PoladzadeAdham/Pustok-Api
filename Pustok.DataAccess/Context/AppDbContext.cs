using Microsoft.EntityFrameworkCore;
using Pustok.Core.Entities;
using Pustok.Core.Entities.Common;
using Pustok.DataAccess.Interceptors;
using System.Reflection;

namespace Pustok.DataAccess.Context
{
    public class AppDbContext(BaseAuditableInterceptor _interceptor, DbContextOptions options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_interceptor);

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Entity<Employee>().HasQueryFilter(x => !x.IsDeleted);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Profession> Professions { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
