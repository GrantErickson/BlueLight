using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueLight.Data.Migrations
{
    /// <inheritdoc />
    public partial class EventRegistrationQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "EventRegistrations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "EventRegistrations");
        }
    }
}
