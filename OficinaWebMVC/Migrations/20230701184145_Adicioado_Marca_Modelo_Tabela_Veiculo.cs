using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OficinaWebMVC.Migrations
{
    /// <inheritdoc />
    public partial class Adicioado_Marca_Modelo_Tabela_Veiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModeloMoto",
                table: "Veiculo",
                newName: "PorteMoto");

            migrationBuilder.RenameColumn(
                name: "ModeloCarro",
                table: "Veiculo",
                newName: "PorteCarro");

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Veiculo",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Veiculo",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Veiculo");

            migrationBuilder.RenameColumn(
                name: "PorteMoto",
                table: "Veiculo",
                newName: "ModeloMoto");

            migrationBuilder.RenameColumn(
                name: "PorteCarro",
                table: "Veiculo",
                newName: "ModeloCarro");
        }
    }
}
