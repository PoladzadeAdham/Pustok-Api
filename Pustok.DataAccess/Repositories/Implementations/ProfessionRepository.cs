using Pustok.Core.Entities;
using Pustok.DataAccess.Context;
using Pustok.DataAccess.Repositories.Abstractions;
using Pustok.DataAccess.Repositories.Implementations.Generic;

namespace Pustok.DataAccess.Repositories.Implementations
{
    internal class ProfessionRepository(AppDbContext _context) : Repository<Profession>(_context), IProfessionRepository
    {

    }
}
