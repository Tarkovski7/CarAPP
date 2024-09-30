using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services.Abstracts;
using DataAccess.Repositories.Abstract;
using Entities.Models;

namespace Business.Services.Concrete
{
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository repository;

        public TypeService(ITypeRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddAsync(Entities.Models.Type type)
        {
            await repository.AddAsync(type);
        }

        public void Delete(Entities.Models.Type type)
        {
            repository.Delete(type);
        }

        public async Task<List<Entities.Models.Type>> GetAllAsync()
        {
            return (List<Entities.Models.Type>)await repository.GetAllAsync();
        }

        public async Task<Entities.Models.Type> GetByIdAsync(Guid id)
        {
            return await repository.GetAsync(type => type.Id == id);
        }

        public void Update(Entities.Models.Type type) 
        { 
            repository.Update(type);
        }
    }
}
