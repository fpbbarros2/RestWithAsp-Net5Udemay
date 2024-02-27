using EvolveDb;
using EvolveDb.Migration;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using RestWithAspNet5UdemayErudio.Bussines;
using RestWithAspNet5UdemayErudio.Bussines.Implementation;
using RestWithAspNet5UdemayErudio.Models.Context;
using RestWithAspNet5UdemayErudio.Repository;
using RestWithAspNet5UdemayErudio.Repository.Generic;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration["ConnectionStrings:MySqlConnectionString"];

builder.Services.AddDbContext<MySqlContext>(options => options.UseMySql(
    connection,
    new MySqlServerVersion(new Version(8, 0, 29)))
);

if (builder.Environment.IsDevelopment())
{
    MigrateDatabase(connection);
}



builder.Services.AddApiVersioning();



builder.Services.AddScoped<IPersonBussines, PersonBussinesImplementation>();
builder.Services.AddScoped<IBookBussines, BookBussinesImplementation>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));







var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void MigrateDatabase(string connection)
{
    try
    {
        var evolveConnection = new MySqlConnection(connection);
        var evolve = new Evolve(evolveConnection, Log.Information)
        {
            Locations = new List<string> { "db/migrations", "db/dataset" },
            IsEraseDisabled = true,
        };
        evolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("Database migration failed", ex);
        throw;
    }
}
