using Pustok.Core.Entities;

namespace Pustok.DataAccess.Constans
{
    public static class SeedData
    {
        public static Status PendingStatus = new Status()
        {
            Id = Guid.Parse("b2fcf88f-3b0e-479d-b642-b49b572341e6"),
            Name = "Pending"
        };
        
        public static Status DoneStatus = new Status()
        {
            Id = Guid.Parse("2a23ac2f-f69e-4318-a861-a74aa724f054"),
            Name = "Done"
        };



    }
}
