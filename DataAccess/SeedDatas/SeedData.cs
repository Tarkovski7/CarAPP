using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.SeedDatas
{
    public static class SeedData
    {
        public static void Init(IServiceProvider serviceProvider)
        {
            using (
                var context = new CarDBContext(
                    serviceProvider.GetRequiredService<DbContextOptions<CarDBContext>>()
                )
            )
            {
                context.Database.Migrate();
                // 1. Brand tablosuna veri ekleme
                if (!context.Brands.Any())
                {
                    var teslaBrand = new Brand { Id = Guid.NewGuid(), Name = "Tesla" };
                    context.Brands.Add(teslaBrand);
                    context.SaveChanges();
                }

                // Tesla Brand'ini al
                var brandId = context.Brands.FirstOrDefault(b => b.Name == "Tesla")?.Id;

                // 2. Seri tablosuna veri ekleme (Seri, BrandId ile ilişkili)
                if (!context.Series.Any())
                {
                    var standardRange = new Seri 
                    { 
                        Id = Guid.NewGuid(), 
                        BrandId = brandId.Value, // Seri, Brand ile ilişkili
                        Name = "Standard Range" 
                    };
                    context.Series.Add(standardRange);
                    context.SaveChanges();
                }

                // Seri ID'sini al
                var seriId = context.Series.FirstOrDefault(s => s.Name == "Standard Range" && s.BrandId == brandId)?.Id;

                // 3. Model tablosuna veri ekleme (Model, SeriId ile ilişkili)
                if (!context.Models.Any())
                {
                    var modelS = new Model
                    {
                        Id = Guid.NewGuid(),
                        SeriId = seriId.Value, // Model, Seri ile ilişkili
                        Name = "Model S",
                    };
                    context.Models.Add(modelS);
                    context.SaveChanges();
                }

                // Model ID'sini al
                var modelId = context.Models.FirstOrDefault(m => m.Name == "Model S" && m.SeriId == seriId)?.Id;

                // 4. Type tablosuna veri ekleme
                if (!context.Types.Any())
                {
                    var sedanType = new Entities.Models.Type
                    {
                        Id = Guid.NewGuid(),
                        Name = "Sedan",
                    };
                    context.Types.Add(sedanType);
                    context.SaveChanges();
                }

                 // Ara tablosu olan ModelTypes tablosuna veri ekleme (ModelId ve TypeId ilişkisi)
               

                // Type ID'sini al
                var typeId = context.Types.FirstOrDefault(t => t.Name == "Sedan")?.Id;
                //  if (modelId != null && typeId != null)
                // {
                //     if (!context.ModelTypes.Any(mt => mt.ModelId == modelId && mt.TypeId == typeId))
                //     {
                //         var modelType = new ModelType
                //         {
                //             ModelId = modelId.Value,
                //             TypeId = typeId.Value
                //         };
                //         context.ModelTypes.Add(modelType);
                //         context.SaveChanges();
                //     }
                // }

                // 5. Cars tablosuna veri ekleme (Car, BrandId, ModelId, SeriId, TypeId ile ilişkili)
                if (brandId != null && modelId != null && seriId != null && typeId != null)
                {
                    if (!context.Cars.Any())
                    {
                        context.Cars.Add(
                            new Car
                            {
                                Id = Guid.NewGuid(),
                                BrandId = brandId.Value,
                                ModelId = modelId.Value,
                                SeriId = seriId.Value,
                                TypeId = typeId.Value,
                                Fuel = Entities.Enums.Fuel.Elektrik,
                                Year = new DateTime(2022, 01, 01),
                            }
                        );
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception(
                        "ID'ler doğru atanmadı. İlişkili tablolar arasında eksik veri olabilir."
                    );
                }
            }
        }
    }
}
