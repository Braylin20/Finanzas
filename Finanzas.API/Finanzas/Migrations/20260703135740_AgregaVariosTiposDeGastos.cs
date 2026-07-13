using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finanzas.Migrations
{
    /// <inheritdoc />
    public partial class AgregaVariosTiposDeGastos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TiposGastos",
                columns: new[] { "TipoGastoId", "Descripcion" },
                values: new object[,]
                {
                    { 6, "Gasolina" },
                    { 7, "Subscripciones" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TiposGastos",
                keyColumn: "TipoGastoId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TiposGastos",
                keyColumn: "TipoGastoId",
                keyValue: 7);
        }
    }
}
