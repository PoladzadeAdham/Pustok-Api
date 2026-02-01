using Microsoft.EntityFrameworkCore;
using Pustok.Core.Entities;
using Pustok.DataAccess.Constans;

namespace Pustok.DataAccess.DataInitializer
{
    public static class SeedDataHelper
    {
        public static void AddSeedDatas(this ModelBuilder modelBuilder)
        {
            Profession defaultProfession = new()
            {
                Id = Guid.Parse("99b14a9d-6c81-4790-aa19-f9085ba4c2b5"),
                Name = "Default profession"
            };

            modelBuilder.Entity<Profession>().HasData(defaultProfession);

            modelBuilder.Entity<Status>().HasData(SeedData.PendingStatus, SeedData.DoneStatus);  

        }

    }
}
