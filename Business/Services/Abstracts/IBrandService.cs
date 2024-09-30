using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Business.Services.Abstracts
{
    public interface IBrandService
    {
        public Task<List<Brand>> GetAllAsync();
        public Task<Brand> GetByIdAsync(Guid id);
        public Task AddAsync(Brand brand);
        public void Update(Brand brand);
        public void Delete(Brand brand);
    }
}