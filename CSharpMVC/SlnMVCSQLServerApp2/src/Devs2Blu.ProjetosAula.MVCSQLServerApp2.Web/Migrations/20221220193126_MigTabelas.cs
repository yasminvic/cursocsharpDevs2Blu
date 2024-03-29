﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Migrations
{
    public partial class MigTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    preco = table.Column<double>(type: "float", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_produtos_categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_produtos_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "categorias",
                columns: new[] { "id", "nome" },
                values: new object[,]
                {
                    { 1, "Alimentos Não Perecíveis" },
                    { 2, "Laticínios" },
                    { 3, "Limpeza" },
                    { 4, "Bebidas Não Alcoólicas" }
                });

            migrationBuilder.InsertData(
                table: "produtos",
                columns: new[] { "id", "CategoriaId", "MarcaId", "nome", "preco", "quantidade" },
                values: new object[,]
                {
                    { 1, 1, null, "Arroz Tio Urbano", 10.0, 5 },
                    { 2, 1, null, "Feijão Tio Urbano", 10.0, 5 },
                    { 3, 2, null, "Queijo", 20.0, 5 },
                    { 4, 2, null, "Iogurte", 20.0, 5 },
                    { 5, 3, null, "Sabão Líquido", 30.0, 5 },
                    { 6, 3, null, "Multiuso", 30.0, 5 },
                    { 7, 4, null, "Suco de Laranja 1L", 40.0, 5 },
                    { 8, 4, null, "Coca-cola 2L", 40.0, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_produtos_CategoriaId",
                table: "produtos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_MarcaId",
                table: "produtos",
                column: "MarcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "Marca");
        }
    }
}
