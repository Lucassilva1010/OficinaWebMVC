using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OficinaWebMVC.Migrations
{
    /// <inheritdoc />
    public partial class Relacionamento_orcamento_Servico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrcamentoServico",
                columns: table => new
                {
                    OrcamentosId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ServicosId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentoServico", x => new { x.OrcamentosId, x.ServicosId });
                    table.ForeignKey(
                        name: "FK_OrcamentoServico_Orcamentos_OrcamentosId",
                        column: x => x.OrcamentosId,
                        principalTable: "Orcamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrcamentoServico_Servicos_ServicosId",
                        column: x => x.ServicosId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoServico_ServicosId",
                table: "OrcamentoServico",
                column: "ServicosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrcamentoServico");
        }
    }
}
