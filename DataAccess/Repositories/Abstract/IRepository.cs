using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Abstract
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Table { get; }
        public Task AddAsync(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        public Task<T> GetAsync(Expression<Func<T, bool>> filter);
        public Task SaveAsync();
    }
}