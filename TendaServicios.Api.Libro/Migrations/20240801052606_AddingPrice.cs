using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TendaServicios.Api.Libro.Migrations
{
    /// <inheritdoc />
    public partial class AddingPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Img",
                table: "LibreriasMaterial",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "LibreriasMaterial",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "LibreriasMaterial");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "LibreriasMaterial");
        }
    }
}
