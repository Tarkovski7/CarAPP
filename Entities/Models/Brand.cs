using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Brand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        //NAV
        public ICollection<Seri> Series { get; set; }
        public ICollection<Car> Cars { get; set; }

    }
}