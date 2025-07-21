using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NorthwindBackend.Bussines.Interfaces.IQueries;
using NorthwindBackend.Bussines.Interfaces.IServices;
using NorthwindBackend.Bussines.Services;
using NorthwindBackend.Data.Context;
using NorthwindBackend.Data.Queries;
using NorthwindBackend.Data.Repositories;
using NorthwindBackend.Domain.Interfaces.IRepositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext with connection string from appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

//Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

//Queries
builder.Services.AddScoped<IEmployeeQueries, EmployeeQueries>();

//Services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

//Mapping

builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile<NorthwindBackend.Bussines.Mapping.DTOsMappingProfile>();
    cfg.AddProfile<NorthwindBackend.Data.Mapping.EntitiesMappingProfile>();
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
