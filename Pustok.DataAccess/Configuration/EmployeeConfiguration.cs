using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pustok.Core.Entities;

namespace Pustok.DataAccess.Configuration
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(256);

            builder.Property(x => x.ImagePath).IsRequired();

            builder.Property(x=>x.Salary).IsRequired();

            builder.HasOne(x => x.Profession).WithMany(x => x.Employees).HasForeignKey(x => x.ProfessionId);


        }
    }
}
