using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WineShop.Data.Migrations
{
    public partial class _01april2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Wine",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AlcoholPercentage",
                table: "Wine",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Wine",
                nullable: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "AlcoholPercentage",
                table: "Wine",
                nullable: false);
        }
    }
}
