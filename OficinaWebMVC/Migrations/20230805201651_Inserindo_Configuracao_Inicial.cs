using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OficinaWebMVC.Migrations
{
    /// <inheritdoc />
    public partial class Inserindo_Configuracao_Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Configuracoes",
                columns: new[] { "Id", "NomeConfiguracao", "ValorConfiguracao" },
                values: new object[] { new Guid("4cee6638-a6b0-48fb-be1e-5bed3d60b196"), "PrazoOrcamento", "10" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Configuracoes",
                keyColumn: "Id",
                keyValue: new Guid("4cee6638-a6b0-48fb-be1e-5bed3d60b196"));
        }
    }
}
