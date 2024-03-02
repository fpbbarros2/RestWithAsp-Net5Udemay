using EvolveDb;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using RestWithAspNet5UdemayErudio.Bussines;
using RestWithAspNet5UdemayErudio.Bussines.Implementation;
using RestWithAspNet5UdemayErudio.Hypermedia.Enricher;
using RestWithAspNet5UdemayErudio.Hypermedia.Filters;
using RestWithAspNet5UdemayErudio.Models.Context;
using RestWithAspNet5UdemayErudio.Repository.Generic;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

var filterOptions = new HyperMediaFilterOptions();
filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
filterOptions.ContentResponseEnricherList.Add(new BookEnricher());

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


// Para aceitar a aplicação usar xml e json
//builder.Services.AddMvc(option => {
//    option.RespectBrowserAcceptHeader = true;
//    option.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json").ToString());
//    option.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml").ToString());
//}).AddXmlSerializerFormatters();

builder.Services.AddApiVersioning();

builder.Services.AddSingleton(filterOptions);

builder.Services.AddScoped<IPersonBussines, PersonBussinesImplementation>();
builder.Services.AddScoped<IBookBussines, BookBussinesImplementation>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute("DefaultApi", "{controller=values}/v{version=apiVersion}/{id?}");

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
