using Microsoft.EntityFrameworkCore;
using ProjetoNotas.Domain.Entities;
using ProjetoNotas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoNotas.Infra.Data.Repository.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> option)
            :base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                new {Id = 1, Name = "Ana da Silva", Login = "aninha", Password = "123"}
                );

            modelBuilder.Entity<Note>()
                .HasData(
                new {Id = 1, UserId = 1, Title = "Aniversário Fulaninho", Description = "Aniversário surpresa de fulano no parque", Category = CategoryEnum.Reminders, Fixed = true, TimeNote = DateTime.Now}
                );
        }

        #region DbSets
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion
    }
}
