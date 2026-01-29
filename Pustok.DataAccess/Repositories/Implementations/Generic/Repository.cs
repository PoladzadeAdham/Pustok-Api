using Microsoft.EntityFrameworkCore;
using Pustok.Core.Entities.Common;
using Pustok.DataAccess.Context;
using Pustok.DataAccess.Repositories.Abstractions.Generic;
using System.Linq.Expressions;

namespace Pustok.DataAccess.Repositories.Implementations.Generic
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll(bool ignoreQueryFilter = false)
        {
            var query = _context.Set<T>().AsQueryable();

            if (ignoreQueryFilter)
            {
                query.IgnoreQueryFilters();
            }


            return query;
        }

        public Task<T?> GetAsync(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<bool> AnyAsync (Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var result = await _context.Set<T>().FindAsync(id);

            return result;
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
