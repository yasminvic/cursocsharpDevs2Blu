using Devs2Blu.PrimeiraAPIASPNetCore.API.Models.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Context SQL Server
var connectionStringUser = builder.Configuration.GetConnectionString("SQLServerConnection");
builder.Services.AddDbContext<SQLServerContext>
    (options => options.UseSqlServer(connectionStringUser));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) //se o ambiente for desenvolvimento, ent apresenta o swagger
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
