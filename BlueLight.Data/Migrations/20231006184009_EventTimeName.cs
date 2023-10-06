using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueLight.Data.Migrations
{
    /// <inheritdoc />
    public partial class EventTimeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "EventTimes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "EventTimes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "EventTimes");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "EventTimes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
