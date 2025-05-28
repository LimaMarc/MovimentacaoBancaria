using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Questao5.Migrations
{
    /// <inheritdoc />
    public partial class EstruturaInicialBaseDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContaCorrente",
                columns: table => new
                {
                    IdContaCorrente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ativo = table.Column<byte>(type: "tinyint", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaCorrente", x => x.IdContaCorrente);
                });

            migrationBuilder.CreateTable(
                name: "Idempotencia",
                columns: table => new
                {
                    ChaveIdempotencia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Requisicao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idempotencia", x => x.ChaveIdempotencia);
                });

            migrationBuilder.CreateTable(
                name: "Movimento",
                columns: table => new
                {
                    IdMovimento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataMovimento = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TipoMovimento = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Valor = table.Column<double>(type: "float(18)", precision: 18, scale: 2, nullable: false),
                    IdContaCorrente = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimento", x => x.IdMovimento);
                    table.ForeignKey(
                        name: "FK_Movimento_ContaCorrente_IdContaCorrente",
                        column: x => x.IdContaCorrente,
                        principalTable: "ContaCorrente",
                        principalColumn: "IdContaCorrente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ContaCorrente",
                columns: new[] { "IdContaCorrente", "Ativo", "Nome", "Numero" },
                values: new object[,]
                {
                    { new Guid("4f581ad0-079d-45c3-89a9-6a62d0c81def"), (byte)0, "Ameena Lyn", 741 },
                    { new Guid("6eb8c77b-5fa1-4681-987b-077164a8c652"), (byte)1, "Katherine Sanchez", 123 },
                    { new Guid("83d9e1d1-01c7-4720-9edd-aa1f2067594c"), (byte)0, "Elisha Simons", 963 },
                    { new Guid("8730e566-e2f2-42b0-b481-397c866ff5d9"), (byte)1, "Tevin Mcconnell", 789 },
                    { new Guid("b1e3a0fc-0326-422a-86e0-d662ed633362"), (byte)1, "Eva Woodward", 456 },
                    { new Guid("c185f76e-76c2-458b-8d8c-70d34bd0d00b"), (byte)0, "Jarrad Mcke", 852 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimento_IdContaCorrente",
                table: "Movimento",
                column: "IdContaCorrente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Idempotencia");

            migrationBuilder.DropTable(
                name: "Movimento");

            migrationBuilder.DropTable(
                name: "ContaCorrente");
        }
    }
}
