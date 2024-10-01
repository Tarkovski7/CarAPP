using Business.Services.Abstracts;
using Business.Services.Concrete;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using DataAccess.SeedDatas;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CarDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr"))
);

builder.Services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IBrandRepository, BrandRepository>();
builder.Services.AddTransient<ICarRepository, CarRepository>();
builder.Services.AddTransient<IModelRepository, ModelRepository>();
builder.Services.AddTransient<ISeriRepository, SeriRepository>();
builder.Services.AddTransient<ITypeRepository, TypeRepository>();

//services
builder.Services.AddTransient<ICarService , CarService>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        SeedData.Init(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers(); 


app.Run();

