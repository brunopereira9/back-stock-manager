using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace stock_manager.Persistence.Migrations
{
    public partial class UpdateSoftDeletes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "StockConferences");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Products",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Products");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "StockConferences",
                type: "datetime2",
                nullable: true);
        }
    }
}
