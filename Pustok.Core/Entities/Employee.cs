using Pustok.Core.Entities.Common;

namespace Pustok.Core.Entities
{
    public class Employee : BaseAuditableEntity
    {
        public string FullName { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public Guid ProfessionId { get; set; }
        public Profession Profession { get; set; }

    }
}
