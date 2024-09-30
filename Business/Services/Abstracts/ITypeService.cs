using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Business.Services.Abstracts
{
    public interface ITypeService
    {
        public Task<List<Entities.Models.Type>> GetAllAsync();
        public Task<Entities.Models.Type> GetByIdAsync(Guid id);
        public Task AddAsync(Entities.Models.Type type);
        public void Update(Entities.Models.Type type);
        public void Delete(Entities.Models.Type type);
    }
}
