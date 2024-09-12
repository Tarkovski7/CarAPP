using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Enums;

namespace Entities.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public Guid BrandId { get; set; }
        public Guid ModelId { get; set; }
        public Guid SeriId { get; set; }
        public Guid TypeId { get; set; }
        public DateTime Year { get; set; }
        public Fuel Fuel { get; set; }

        //NAV
        public Brand Brand { get; set; }
        public Seri Seri { get; set; }
        public Model Model { get; set; }
        public Type Type { get; set; }
    }
}