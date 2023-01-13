using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Devs2Blu.AgendaContato.ProjetoMVC.Migrations
{
    /// <inheritdoc />
    public partial class InicialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contatos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contatos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "compromissos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContatoId = table.Column<int>(type: "int", nullable: false),
                    cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    num = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uf = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compromissos", x => x.id);
                    table.ForeignKey(
                        name: "FK_compromissos_contatos_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "contatos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "contatos",
                columns: new[] { "id", "email", "nome", "telefone" },
                values: new object[,]
                {
                    { 1, "jose@gmail.com", "José", "999999999" },
                    { 2, "karina@gmail.com", "Karina", "999883922" }
                });

            migrationBuilder.InsertData(
                table: "compromissos",
                columns: new[] { "id", "bairro", "cep", "cidade", "ContatoId", "descricao", "num", "rua", "titulo", "uf" },
                values: new object[] { 1, "Fortaleza", "89055550", "Blumenau", 1, "Aniversário de 53 anos", "180", "Roseli Rosani Burkhardt", "Aniversário", "SC" });

            migrationBuilder.CreateIndex(
                name: "IX_compromissos_ContatoId",
                table: "compromissos",
                column: "ContatoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "compromissos");

            migrationBuilder.DropTable(
                name: "contatos");
        }
    }
}
