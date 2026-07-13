using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finanzas.Migrations
{
    /// <inheritdoc />
    public partial class AgregaVariosMetodosDePagos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MetodosPago",
                columns: new[] { "MetodoPagoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Efectivo" },
                    { 2, "Tarjeta de crédito" },
                    { 3, "Tarjeta de débito" },
                    { 4, "Transferencia bancaria" },
                    { 7, "Otro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MetodosPago",
                keyColumn: "MetodoPagoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MetodosPago",
                keyColumn: "MetodoPagoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MetodosPago",
                keyColumn: "MetodoPagoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MetodosPago",
                keyColumn: "MetodoPagoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MetodosPago",
                keyColumn: "MetodoPagoId",
                keyValue: 7);
        }
    }
}
