using Microsoft.EntityFrameworkCore;
using Pustok.Core.Entities;
using System.Reflection;

namespace Pustok.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Profession> Professions { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
