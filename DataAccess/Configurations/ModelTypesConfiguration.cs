using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ModelTypesConfiguration: IEntityTypeConfiguration<ModelTypes>
    {
        public void Configure(EntityTypeBuilder<ModelTypes> builder)
        {
            builder.HasKey(mt => new { mt.ModelId, mt.TypeId });

            builder
                .HasOne(mt => mt.Model)
                .WithMany(t => t.Types)
                .HasForeignKey(mt => mt.ModelId).OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(mt => mt.Type)
                .WithMany(m => m.Models)
                .HasForeignKey(mt => mt.TypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}