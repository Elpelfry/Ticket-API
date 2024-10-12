using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketApi.Migrations
{
    /// <inheritdoc />
    public partial class name_sistema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sistema",
                table: "Sistemas",
                newName: "Nombre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Sistemas",
                newName: "Sistema");
        }
    }
}
