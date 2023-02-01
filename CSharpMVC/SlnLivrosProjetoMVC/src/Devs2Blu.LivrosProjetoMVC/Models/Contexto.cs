using Microsoft.EntityFrameworkCore;

namespace Devs2Blu.LivrosProjetoMVC.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {

        }

        #region TABELAS
        public DbSet<Livros> Livros { get; set; }
        #endregion
    }
}
