using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services.Abstracts;
using DataAccess.Repositories.Abstract;
using Entities.Models;

namespace Business.Services.Concrete
{
    public class SeriService : ISeriService
    {
        private readonly ISeriRepository repository;

        public SeriService(ISeriRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddAsync(Seri seri)
        {
            await repository.AddAsync(seri);
        }

        public void Delete(Seri seri)
        {
            repository.Delete(seri);
        }

        public async Task<List<Seri>> GetAllAsync()
        {
            return (List<Seri>)await repository.GetAllAsync();
        }

        public async Task<Seri> GetByIdAsync(Guid id)
        {
            return await repository.GetAsync(seri => seri.Id == id);
        }

        public void Update(Seri seri)
        {
            repository.Update(seri);
        }
    }
}