using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class TypeConfiguration : IEntityTypeConfiguration<Entities.Models.Type>
    {
        public void Configure(EntityTypeBuilder<Entities.Models.Type> builder)
        {
            
        }
    }
}