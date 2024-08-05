using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TendaServicios.Api.Libro.Migrations
{
    /// <inheritdoc />
    public partial class addingDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Img",
                table: "LibreriasMaterial",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "LibreriasMaterial",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "LibreriasMaterial");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Img",
                table: "LibreriasMaterial",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);
        }
    }
}
