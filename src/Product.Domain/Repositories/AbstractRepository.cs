using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Product.Domain.Repositories
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;

        protected AbstractRepository(DbContext context)
        {
            context = _context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}