using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using Entities.Models;

namespace DataAccess.Repositories.Concrete
{
    public class ModelRepository : BaseRepository<Model>, IModelRepository
    {
        public ModelRepository(CarDBContext context) : base(context)
        {
        }
    }
}