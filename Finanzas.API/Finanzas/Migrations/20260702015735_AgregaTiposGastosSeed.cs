using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finanzas.Migrations
{
    /// <inheritdoc />
    public partial class AgregaTiposGastosSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TiposGastos",
                columns: new[] { "TipoGastoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Alimentos" },
                    { 2, "Transporte" },
                    { 3, "Servicios" },
                    { 4, "Ocio" },
                    { 5, "Salud" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_TipoGastoId",
                table: "Gastos",
                column: "TipoGastoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_TiposGastos_TipoGastoId",
                table: "Gastos",
                column: "TipoGastoId",
                principalTable: "TiposGastos",
                principalColumn: "TipoGastoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gastos_TiposGastos_TipoGastoId",
                table: "Gastos");

            migrationBuilder.DropIndex(
                name: "IX_Gastos_TipoGastoId",
                table: "Gastos");

            migrationBuilder.DeleteData(
                table: "TiposGastos",
                keyColumn: "TipoGastoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TiposGastos",
                keyColumn: "TipoGastoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TiposGastos",
                keyColumn: "TipoGastoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TiposGastos",
                keyColumn: "TipoGastoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TiposGastos",
                keyColumn: "TipoGastoId",
                keyValue: 5);
        }
    }
}
