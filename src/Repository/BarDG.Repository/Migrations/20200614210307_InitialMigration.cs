using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BarDG.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comandas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comandas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TotalDesconto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    ComandaId = table.Column<Guid>(nullable: true),
                    NotaFiscalId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Comandas_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comandas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produtos_NotaFiscals_NotaFiscalId",
                        column: x => x.NotaFiscalId,
                        principalTable: "NotaFiscals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "ComandaId", "Descricao", "NotaFiscalId", "Valor" },
                values: new object[] { new Guid("ef91528e-d3e9-450e-a75a-4b35e0ae8df2"), null, "Cerveja", null, 5m });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "ComandaId", "Descricao", "NotaFiscalId", "Valor" },
                values: new object[] { new Guid("22bf78e3-5dfc-4444-a7fd-f30e4e0c2ea4"), null, "Conhaque", null, 20m });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "ComandaId", "Descricao", "NotaFiscalId", "Valor" },
                values: new object[] { new Guid("5cb07a8d-dc78-49d3-a494-95e54630c6bc"), null, "Suco", null, 50m });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "ComandaId", "Descricao", "NotaFiscalId", "Valor" },
                values: new object[] { new Guid("5386c928-176e-42e2-a431-0b4cc70c405b"), null, "Água", null, 70m });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ComandaId",
                table: "Produtos",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_NotaFiscalId",
                table: "Produtos",
                column: "NotaFiscalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Comandas");

            migrationBuilder.DropTable(
                name: "NotaFiscals");
        }
    }
}
