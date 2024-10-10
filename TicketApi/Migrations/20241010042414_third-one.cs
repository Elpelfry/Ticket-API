using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketApi.Migrations
{
    /// <inheritdoc />
    public partial class thirdone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Units",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Units",
                table: "Products");
        }
    }
}
