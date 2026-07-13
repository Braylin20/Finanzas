using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finanzas.Migrations
{
    /// <inheritdoc />
    public partial class AgregaMetodosDePagos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MetodoPagoId",
                table: "Gastos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MetodosPago",
                columns: table => new
                {
                    MetodoPagoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodosPago", x => x.MetodoPagoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_MetodoPagoId",
                table: "Gastos",
                column: "MetodoPagoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_MetodosPago_MetodoPagoId",
                table: "Gastos",
                column: "MetodoPagoId",
                principalTable: "MetodosPago",
                principalColumn: "MetodoPagoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gastos_MetodosPago_MetodoPagoId",
                table: "Gastos");

            migrationBuilder.DropTable(
                name: "MetodosPago");

            migrationBuilder.DropIndex(
                name: "IX_Gastos_MetodoPagoId",
                table: "Gastos");

            migrationBuilder.DropColumn(
                name: "MetodoPagoId",
                table: "Gastos");
        }
    }
}
