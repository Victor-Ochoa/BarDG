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
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comandas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscais",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    CompraMaxima = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: true),
                    Desconto = table.Column<decimal>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    ComandaId = table.Column<Guid>(nullable: true),
                    NotaFiscalId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itens_Comandas_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comandas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Itens_NotaFiscais_NotaFiscalId",
                        column: x => x.NotaFiscalId,
                        principalTable: "NotaFiscais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Itens_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CompraMaxima", "Descricao", "Valor" },
                values: new object[] { new Guid("c18491ae-c297-48ae-933b-f911b05c4f19"), 0, "Cerveja", 5m });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CompraMaxima", "Descricao", "Valor" },
                values: new object[] { new Guid("f0f9cfc9-bc71-4e2f-814a-1ed899f7d68d"), 0, "Conhaque", 20m });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CompraMaxima", "Descricao", "Valor" },
                values: new object[] { new Guid("798dcd64-a060-4e33-a96a-9955b92dc0ba"), 3, "Suco", 50m });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CompraMaxima", "Descricao", "Valor" },
                values: new object[] { new Guid("0535425a-93d6-4841-a75a-f1a79abfc7aa"), 0, "Água", 70m });

            migrationBuilder.CreateIndex(
                name: "IX_Itens_ComandaId",
                table: "Itens",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_NotaFiscalId",
                table: "Itens",
                column: "NotaFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_ProdutoId",
                table: "Itens",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "Comandas");

            migrationBuilder.DropTable(
                name: "NotaFiscais");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
