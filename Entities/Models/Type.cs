using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Type
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        //NAV
        public ICollection<ModelTypes> Models { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
