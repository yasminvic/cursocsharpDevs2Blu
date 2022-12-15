using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models;
using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Repository;
using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Service.Implements;
using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Context DB SQL Server
builder.Services.AddDbContext<ContextoDatabase>
    (options => options.UseSqlServer("Server=LAPTOP-EBG33A6E\\SQLEXPRESS;Database=ListaCompras;User Id=sa;Password=gibi2016;TrustServerCertificate=True;"));


/*
 *Dependency Injection
 */

//mapeamento das classes que queremos que seja feita a injection

//Repositories
builder.Services.AddScoped<CategoriaRepository, CategoriaRepository>(); //vai mapear si própria

//Services
builder.Services.AddScoped<ICategoriasService, CategoriasService>();

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
