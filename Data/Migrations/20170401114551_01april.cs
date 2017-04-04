using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WineShop.Data.Migrations
{
    public partial class _01april : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Wine",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Wine",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AlcoholPercentage",
                table: "Wine",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Wine",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "ImagePath",
                table: "Wine",
                nullable: false);

            migrationBuilder.AlterColumn<double>(
                name: "AlcoholPercentage",
                table: "Wine",
                nullable: false);
        }
    }
}
