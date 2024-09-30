using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services.Abstracts;
using DataAccess.Repositories.Abstract;
using Entities.Models;

namespace Business.Services.Concrete
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository repository;

        public ModelService(IModelRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddAsync(Model model) { 
            await repository.AddAsync(model);
        }

        public void Delete(Model model) {
            repository.Delete(model);
         }

        public async Task<List<Model>> GetAllAsync() {
            return (List<Model>)await repository.GetAllAsync();
         }

        public async Task<Model> GetByIdAsync(Guid id) {
            return await repository.GetAsync(model => model.Id == id);
         }

        public void Update(Model model) {
            repository.Update(model);
         }
    }
}
