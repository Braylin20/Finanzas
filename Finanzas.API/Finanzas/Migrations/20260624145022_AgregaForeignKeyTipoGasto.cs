using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finanzas.Migrations
{
    /// <inheritdoc />
    public partial class AgregaForeignKeyTipoGasto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoGastoId",
                table: "Gastos",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoGastoId",
                table: "Gastos");
        }
    }
}
