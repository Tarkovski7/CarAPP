using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Seri
    {
        public Guid Id { get; set; }
        public Guid BrandId { get; set; }
        public string Name { get; set; }

        //NAV
        public Brand Brand { get; set; }
        public ICollection<Car> Cars { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}
