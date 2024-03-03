using EvolveDb;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using RestWithAspNet5UdemayErudio.Bussines;
using RestWithAspNet5UdemayErudio.Bussines.Implementation;
using RestWithAspNet5UdemayErudio.Hypermedia.Enricher;
using RestWithAspNet5UdemayErudio.Hypermedia.Filters;
using RestWithAspNet5UdemayErudio.Models.Context;
using RestWithAspNet5UdemayErudio.Repository.Generic;

using Serilog;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

var filterOptions = new HyperMediaFilterOptions();
filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
filterOptions.ContentResponseEnricherList.Add(new BookEnricher());


builder.Services.AddRouting(op => op.LowercaseUrls = true);


builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));


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
builder.Services.AddMvc(option =>
{
    option.RespectBrowserAcceptHeader = true;
    option.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json").ToString());
    option.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml").ToString());
}).AddXmlSerializerFormatters();

builder.Services.AddApiVersioning();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Rest Api's from 0 to azure",
        Version = "v1",
        Description = "Api restfull developed",
        Contact = new OpenApiContact
        {
            Name = "Fábio Barros",
            Url = new Uri("https://www.google.com.br")
        }
    });
});




builder.Services.AddSingleton(filterOptions);

builder.Services.AddScoped<IPersonBussines, PersonBussinesImplementation>();
builder.Services.AddScoped<IBookBussines, BookBussinesImplementation>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));


var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rest API - v1"); });


var options = new RewriteOptions();
options.AddRedirect("^$", "swagger");
app.UseRewriter(options);

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
