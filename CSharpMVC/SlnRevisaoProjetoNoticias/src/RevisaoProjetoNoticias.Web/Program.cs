using Microsoft.EntityFrameworkCore;
using RevisaoProjetoNoticias.Domain.IRepositories;
using RevisaoProjetoNoticias.Infra.Data.Context;
using RevisaoProjetoNoticias.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SQLServerContext>
    (options => options.UseSqlServer("Server=LAPTOP-EBG33A6E\\SQLEXPRESS;Database=NewsPage;User Id=sa;Password=gibi2016;TrustServerCertificate=True;"));

//Injen��o de depend�ncia
// *Repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
