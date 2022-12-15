﻿// <auto-generated />
using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Migrations
{
    [DbContext(typeof(ContextoDatabase))]
    partial class ContextoDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Alimentos Não Perecíveis"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Laticínios"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Limpeza"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Bebidas Não Alcoólicas"
                        });
                });

            modelBuilder.Entity("Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int")
                        .HasColumnName("CategoriaId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.Property<double>("Preco")
                        .HasColumnType("float")
                        .HasColumnName("preco");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("quantidade");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("produtos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoriaId = 1,
                            Nome = "Arroz Tio Urbano",
                            Preco = 10.0,
                            Quantidade = 5
                        },
                        new
                        {
                            Id = 2,
                            CategoriaId = 1,
                            Nome = "Feijão Tio Urbano",
                            Preco = 10.0,
                            Quantidade = 5
                        },
                        new
                        {
                            Id = 3,
                            CategoriaId = 2,
                            Nome = "Queijo",
                            Preco = 20.0,
                            Quantidade = 5
                        },
                        new
                        {
                            Id = 4,
                            CategoriaId = 2,
                            Nome = "Iogurte",
                            Preco = 20.0,
                            Quantidade = 5
                        },
                        new
                        {
                            Id = 5,
                            CategoriaId = 3,
                            Nome = "Sabão Líquido",
                            Preco = 30.0,
                            Quantidade = 5
                        },
                        new
                        {
                            Id = 6,
                            CategoriaId = 3,
                            Nome = "Multiuso",
                            Preco = 30.0,
                            Quantidade = 5
                        },
                        new
                        {
                            Id = 7,
                            CategoriaId = 4,
                            Nome = "Suco de Laranja 1L",
                            Preco = 40.0,
                            Quantidade = 5
                        },
                        new
                        {
                            Id = 8,
                            CategoriaId = 4,
                            Nome = "Coca-cola 2L",
                            Preco = 40.0,
                            Quantidade = 5
                        });
                });

            modelBuilder.Entity("Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.Entities.Produto", b =>
                {
                    b.HasOne("Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.Entities.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.Entities.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
