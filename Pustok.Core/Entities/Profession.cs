using Pustok.Core.Entities.Common;

namespace Pustok.Core.Entities
{
    public class Profession : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Employee> Employees { get; set; }
    }
}
