using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Finanzas.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetodosPago",
                columns: table => new
                {
                    MetodoPagoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodosPago", x => x.MetodoPagoId);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Monto = table.Column<double>(type: "double precision", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                });

            migrationBuilder.CreateTable(
                name: "TiposGastos",
                columns: table => new
                {
                    TipoGastoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposGastos", x => x.TipoGastoId);
                });

            migrationBuilder.CreateTable(
                name: "Gastos",
                columns: table => new
                {
                    GastoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoGastoId = table.Column<int>(type: "integer", nullable: true),
                    MetodoPagoId = table.Column<int>(type: "integer", nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Monto = table.Column<double>(type: "double precision", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gastos", x => x.GastoId);
                    table.ForeignKey(
                        name: "FK_Gastos_MetodosPago_MetodoPagoId",
                        column: x => x.MetodoPagoId,
                        principalTable: "MetodosPago",
                        principalColumn: "MetodoPagoId");
                    table.ForeignKey(
                        name: "FK_Gastos_TiposGastos_TipoGastoId",
                        column: x => x.TipoGastoId,
                        principalTable: "TiposGastos",
                        principalColumn: "TipoGastoId");
                });

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

            migrationBuilder.InsertData(
                table: "TiposGastos",
                columns: new[] { "TipoGastoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Alimentos" },
                    { 2, "Transporte" },
                    { 3, "Servicios" },
                    { 4, "Ocio" },
                    { 5, "Salud" },
                    { 6, "Gasolina" },
                    { 7, "Subscripciones" },
                    { 8, "Supermercado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_MetodoPagoId",
                table: "Gastos",
                column: "MetodoPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_TipoGastoId",
                table: "Gastos",
                column: "TipoGastoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gastos");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "MetodosPago");

            migrationBuilder.DropTable(
                name: "TiposGastos");
        }
    }
}
