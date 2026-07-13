using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finanzas.Migrations
{
    /// <inheritdoc />
    public partial class AgregaTipoGasto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposGastos",
                columns: table => new
                {
                    TipoGastoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposGastos", x => x.TipoGastoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiposGastos");
        }
    }
}
