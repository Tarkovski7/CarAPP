using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Concrete
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly CarDBContext _context;

        public BaseRepository(CarDBContext context)
        {
            _context = context;
        }
        
        public DbSet<T> Table => _context.Set<T>();

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            return await Table.Where(filter).ToListAsync();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return Table.FirstOrDefaultAsync(filter);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }
    }
}