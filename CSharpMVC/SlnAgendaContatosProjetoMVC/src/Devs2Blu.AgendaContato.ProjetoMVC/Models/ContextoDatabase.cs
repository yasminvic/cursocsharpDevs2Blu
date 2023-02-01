using Devs2Blu.AgendaContato.ProjetoMVC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devs2Blu.AgendaContato.ProjetoMVC.Models
{
    public class ContextoDatabase : DbContext
    {
        public ContextoDatabase(DbContextOptions<ContextoDatabase> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //definindo foreign key
            modelBuilder.Entity<Compromisso>()
                .HasOne(comp => comp.Contato)
                .WithMany(cont => cont.Compromissos)
                .HasForeignKey(comp => comp.ContatoId);

            //criando registros 

            modelBuilder.Entity<Contato>()
                .HasData(
                    new { Id = 1, Nome = "José", Telefone = "999999999", Email = "jose@gmail.com" },
                    new { Id = 2, Nome = "Karina", Telefone = "999883922", Email = "karina@gmail.com" }
                );

            modelBuilder.Entity<Compromisso>()
                .HasData(
                    new {Id = 1, Titulo = "Aniversário", Descricao = "Aniversário de 53 anos", ContatoId = 1, CEP = "89055550", Rua = "Roseli Rosani Burkhardt", Bairro = "Fortaleza", Num = "180", Cidade = "Blumenau", UF = "SC" }
                );

            base.OnModelCreating(modelBuilder);
        }

        #region DbSets
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Compromisso> Compromisso { get; set; }

        #endregion
    }
}
