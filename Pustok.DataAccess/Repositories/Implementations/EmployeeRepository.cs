using Pustok.Core.Entities;
using Pustok.DataAccess.Context;
using Pustok.DataAccess.Repositories.Abstractions;
using Pustok.DataAccess.Repositories.Implementations.Generic;

namespace Pustok.DataAccess.Repositories.Implementations
{
    internal class EmployeeRepository(AppDbContext _context) : Repository<Employee>(_context), IEmployeeRepository
    {


    }
}
