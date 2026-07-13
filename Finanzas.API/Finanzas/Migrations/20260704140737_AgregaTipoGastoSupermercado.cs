using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finanzas.Migrations
{
    /// <inheritdoc />
    public partial class AgregaTipoGastoSupermercado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TiposGastos",
                columns: new[] { "TipoGastoId", "Descripcion" },
                values: new object[] { 8, "Supermercado" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TiposGastos",
                keyColumn: "TipoGastoId",
                keyValue: 8);
        }
    }
}
