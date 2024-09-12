using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using Entities.Models;

namespace DataAccess.Repositories.Concrete
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(CarDBContext context) : base(context)
        {
        }
    }
}