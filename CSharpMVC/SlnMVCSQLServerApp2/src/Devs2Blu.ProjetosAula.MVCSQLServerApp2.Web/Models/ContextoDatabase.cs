using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models
{
    //cria um ambiente de banco de dados pra fazer transições
    //esse aqui é pra SQLServer, mas poderia ter pra mysql
    public class ContextoDatabase : DbContext //herda desse cara
    {
        public ContextoDatabase(DbContextOptions<ContextoDatabase> options)
            : base(options) //isso é um super.__init__ //ta inicializando options de DbContext
        {
             
        }

        //sob-escrevemos esse metodo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mapeamento de relacionamento

            //construtor da model, vai pegar essa confg todas das tabelas e criar pra gente
            modelBuilder.Entity<Produto>()//entidade que vamos buildar
                .HasOne(p => p.Categoria) //ta dizendo que existe um relacionamento entre categoria e produto
                .WithMany(c => c.Produtos);

            //ta dizendo que tem uma categoria dentro de produtos, com vários produtos dentro de categoria

            base.OnModelCreating(modelBuilder);
        }

        #region DbSets
        //colocamos todas nossas tabelas aqui
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        #endregion
    }
}
