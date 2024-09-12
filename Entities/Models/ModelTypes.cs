using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ModelTypes
    {
         public Guid ModelId { get; set; }
        public Guid TypeId { get; set; }

        //NAV
        public Model Model { get; set; }
        public Type Type { get; set; }
    }
}