using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TendaServicios.Api.Libro.Migrations
{
    /// <inheritdoc />
    public partial class InitDB1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CuponId",
                table: "LibreriasMaterial",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CuponId",
                table: "LibreriasMaterial");
        }
    }
}
