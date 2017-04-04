using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WineShop.Data.Migrations
{
    public partial class _04april01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Cart",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ClientID",
                table: "Cart",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_StatusID",
                table: "Cart",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_WineID",
                table: "Cart",
                column: "WineID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_User_ClientID",
                table: "Cart",
                column: "ClientID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Status_StatusID",
                table: "Cart",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Wine_WineID",
                table: "Cart",
                column: "WineID",
                principalTable: "Wine",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_User_ClientID",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Status_StatusID",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Wine_WineID",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_ClientID",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_StatusID",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_WineID",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Cart");
        }
    }
}
