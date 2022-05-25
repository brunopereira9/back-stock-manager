using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace stock_manager.Persistence.Migrations
{
    public partial class AddSoftDeletes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "StockConferences");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "StockConferences",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StockConferences",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "StockConferences");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StockConferences");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "StockConferences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
