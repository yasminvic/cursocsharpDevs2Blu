﻿// <auto-generated />
using Devs2Blu.PrimeiraAPIASPNetCore.API.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Devs2Blu.PrimeiraAPIASPNetCore.API.Migrations
{
    [DbContext(typeof(SQLServerContext))]
    partial class SQLServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Devs2Blu.PrimeiraAPIASPNetCore.API.Models.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contact1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Contact1 = "47988556622",
                            Email = "anasilva@email.com",
                            Name = "Ana Silva"
                        },
                        new
                        {
                            Id = 2,
                            Contact1 = "47988554422",
                            Email = "arnaldosilva@email.com",
                            Name = "Arnaldo Silva"
                        },
                        new
                        {
                            Id = 3,
                            Contact1 = "47988335599",
                            Email = "carlossilva@email.com",
                            Name = "Carlos Silva"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
