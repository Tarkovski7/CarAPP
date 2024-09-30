using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Business.Services.Abstracts
{
    public interface ICarService
    {
        public Task<List<Car>> GetAllAsync();
        public Task<Car> GetByIdAsync(Guid id);
        public Task AddAsync(Car car);
        public void Update(Car car);
        public void Delete(Car car);
    }
}
