using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketApi.Migrations
{
    /// <inheritdoc />
    public partial class names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreSistema",
                table: "Sistemas",
                newName: "Sistema");

            migrationBuilder.RenameColumn(
                name: "DescripcionSistema",
                table: "Sistemas",
                newName: "Descripcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sistema",
                table: "Sistemas",
                newName: "NombreSistema");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Sistemas",
                newName: "DescripcionSistema");
        }
    }
}
