using Devs2Blu.AgendaContato.ProjetoMVC.Models;
using Devs2Blu.AgendaContato.ProjetoMVC.Models.Entities;
using Devs2Blu.AgendaContato.ProjetoMVC.Repository;
using Devs2Blu.AgendaContato.ProjetoMVC.Service.Implements;
using Devs2Blu.AgendaContato.ProjetoMVC.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Context DB SQL Server
builder.Services.AddDbContext<ContextoDatabase>
    (options => options.UseSqlServer("Server=LAPTOP-EBG33A6E\\SQLEXPRESS;Database=AgendaContato;User Id=sa;Password=gibi2016;TrustServerCertificate=True;"));

/*
 *Dependency Injection
 *
 * mapeamento das classes que queremos que seja feita a injection
 */
//compromisso
builder.Services.AddScoped<CompromissoRepository, CompromissoRepository>();
builder.Services.AddScoped<ICompromissoService, CompromissoService>();
//contato
builder.Services.AddScoped<ContatoRepository, ContatoRepository>();
builder.Services.AddScoped<IContatoService, ContatoService>();

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
