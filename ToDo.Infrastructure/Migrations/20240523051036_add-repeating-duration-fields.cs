using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addrepeatingdurationfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "ToDoLists",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Repeating",
                table: "ToDoLists",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "ToDoLists");

            migrationBuilder.DropColumn(
                name: "Repeating",
                table: "ToDoLists");
        }
    }
}
