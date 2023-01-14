﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RevisaoProjetoNoticias.Infra.Data.Context;

#nullable disable

namespace RevisaoProjetoNoticias.Infra.Data.Migrations
{
    [DbContext(typeof(SQLServerContext))]
    [Migration("20230113214759_Tabelas")]
    partial class Tabelas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RevisaoProjetoNoticias.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Destaque"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Programação"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Jogos"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Negócios"
                        });
                });

            modelBuilder.Entity("RevisaoProjetoNoticias.Domain.Entities.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdOn");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<bool>("Published")
                        .HasColumnType("bit")
                        .HasColumnName("published");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("news");
                });

            modelBuilder.Entity("RevisaoProjetoNoticias.Domain.Entities.News", b =>
                {
                    b.HasOne("RevisaoProjetoNoticias.Domain.Entities.Category", "Category")
                        .WithMany("NewsList")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RevisaoProjetoNoticias.Domain.Entities.Category", b =>
                {
                    b.Navigation("NewsList");
                });
#pragma warning restore 612, 618
        }
    }
}
