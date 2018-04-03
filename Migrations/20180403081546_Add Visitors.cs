using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace webdev.Migrations
{
    public partial class AddVisitors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Visitors",
                table: "Links",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visitors",
                table: "Links");
        }
    }
}
