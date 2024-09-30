using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services.Abstracts;
using DataAccess.Repositories.Abstract;
using Entities.Models;

namespace Business.Services.Concrete
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository repository;
        public BrandService(IBrandRepository repository)
        {
            this.repository = repository;
            
        }
        public async Task AddAsync(Brand brand)
        {
            await repository.AddAsync(brand);
        }

        public void Delete(Brand brand)
        {
            repository.Delete(brand);
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            return (List<Brand>)await repository.GetAllAsync();
        }

        public async Task<Brand> GetByIdAsync(Guid id)
        {
            return await repository.GetAsync(brand => brand.Id == id);
        }

        public void Update(Brand brand)
        {
            repository.Update(brand);
        }
    }
}