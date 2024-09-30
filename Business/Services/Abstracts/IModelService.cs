using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Business.Services.Abstracts
{
    public interface IModelService
    {
        public Task<List<Model>> GetAllAsync();

        public Task<Model> GetByIdAsync(Guid id);

        public Task AddAsync(Model model);

        public void Update(Model model);

        public void Delete(Model model);
    }
}
