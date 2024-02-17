using Microsoft.EntityFrameworkCore;
using RestWithAspNet5UdemayErudio.Models.Context;
using RestWithAspNet5UdemayErudio.Services;
using RestWithAspNet5UdemayErudio.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration["ConnectionStrings:MySqlConnectionString"];

builder.Services.AddDbContext<MySqlContext>(option => option.UseMySql(connection, new MySqlServerVersion(new Version(8,0,29))) );



builder.Services.AddApiVersioning();



builder.Services.AddScoped<IPersonServices, PersonServiceImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
