using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Context DB SQL Server //tem que fazer isso antes do Build
builder.Services.AddDbContext<ContextoDatabase>
    //é tipo uma arrow function
    (options => options.UseSqlServer("Server=LAPTOP-EBG33A6E\\SQLEXPRESS;Database=ListaCompras;User Id=sa;Password=gibi2016;"));
    //a gente podia colocar vários contextos

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
