using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Model
    {
        public Guid Id { get; set; }
        public Guid SeriId { get; set; }
        public string Name { get; set; }

        //NAV
        public Seri Seri { get; set; }
        public ICollection<Car> Cars { get; set; }
        public ICollection<ModelTypes> Types { get; set; }
    }
}