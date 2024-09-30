using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Business.Services.Abstracts
{
    public interface ISeriService
    {
        public Task<List<Seri>> GetAllAsync();
        public Task<Seri> GetByIdAsync(Guid id);
        public Task AddAsync(Seri seri);
        public void Update(Seri seri);
        public void Delete(Seri seri);
    }
}
