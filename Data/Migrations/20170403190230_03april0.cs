using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WineShop.Data.Migrations
{
    public partial class _03april0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Cart");

            migrationBuilder.AddColumn<int>(
                name: "WineID",
                table: "Cart",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WineID",
                table: "Cart");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Cart",
                nullable: false,
                defaultValue: 0);
        }
    }
}
