using Exercices10.Models;
using Exercices10.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<boey_webserveurContext>(
    options => options.UseMySql(
        builder.Configuration.GetConnectionString("MyDb"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.7-mariadb")
        )
    );
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();

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
