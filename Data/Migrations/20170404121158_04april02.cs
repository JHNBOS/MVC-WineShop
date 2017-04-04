using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WineShop.Data.Migrations
{
    public partial class _04april02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Status_StatusID",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_StatusID",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "Cart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "Cart",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_StatusID",
                table: "Cart",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Status_StatusID",
                table: "Cart",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
