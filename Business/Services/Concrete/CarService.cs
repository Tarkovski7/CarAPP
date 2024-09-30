using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services.Abstracts;
using DataAccess.Repositories.Abstract;
using Entities.Models;

namespace Business.Services.Concrete
{
    public class CarService : ICarService
    {
        private readonly ICarRepository repository;

        public CarService(ICarRepository repo)
        {
            repository = repo;
        }

        public async Task AddAsync(Car car)
        {
            await repository.AddAsync(car);
        }

        public void Delete(Car car)
        {
            repository.Delete(car);
        }

        public async Task<List<Car>> GetAllAsync()
        {
            return (List<Car>)await repository.GetAllAsync();
        }

        public async Task<Car> GetByIdAsync(Guid id)
        {
            return await repository.GetAsync(car => car.Id == id);
        }

        public void Update(Car car) 
        {
            repository.Update(car);
        }
    }
}
