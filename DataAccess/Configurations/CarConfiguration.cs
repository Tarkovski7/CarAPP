using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");

            // Primary Key
            builder.HasKey(c => c.Id);

            // Relationships
            builder
                .HasOne(c => c.Brand)
                .WithMany(b => b.Cars)
                .HasForeignKey(c => c.BrandId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict deletion if Brand has related Cars

            builder
                .HasOne(c => c.Seri)
                .WithMany(s => s.Cars)
                .HasForeignKey(c => c.SeriId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict deletion if Seri has related Cars

            builder
                .HasOne(c => c.Model)
                .WithMany(m => m.Cars)
                .HasForeignKey(c => c.ModelId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict deletion if Model has related Cars

            builder
                .HasOne(c => c.Type)
                .WithMany(t => t.Cars)
                .HasForeignKey(c => c.TypeId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict deletion if Type has related Cars

            // Fields
            builder.Property(c => c.Year)
                .IsRequired();

            builder.Property(c => c.Fuel)
                .IsRequired()
                .HasConversion<int>(); // Assuming Fuel is an Enum and stored as int in the DB
        }
    }
}