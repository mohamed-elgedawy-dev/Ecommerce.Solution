﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Repository.Data.Migrations
{
    public partial class _Product_Module : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductsBrands_ProductBrandId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductBrandId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductBrandId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductBrandId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBrandId",
                table: "Products",
                column: "ProductBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductsBrands_ProductBrandId",
                table: "Products",
                column: "ProductBrandId",
                principalTable: "ProductsBrands",
                principalColumn: "Id");
        }
    }
}
