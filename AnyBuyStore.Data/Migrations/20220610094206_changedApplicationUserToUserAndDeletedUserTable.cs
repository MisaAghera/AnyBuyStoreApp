using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnyBuyStore.Data.Migrations
{
    public partial class changedApplicationUserToUserAndDeletedUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_User_user_id",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_user_id",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCart_User_user_id",
                table: "ProductCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductWish_User_user_id",
                table: "ProductWish");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Address_user_id",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Address_user_id",
                table: "Address",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AspUser_user_id",
                table: "Address",
                column: "user_id",
                principalTable: "AspUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspUser_user_id",
                table: "Order",
                column: "user_id",
                principalTable: "AspUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCart_AspUser_user_id",
                table: "ProductCart",
                column: "user_id",
                principalTable: "AspUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWish_AspUser_user_id",
                table: "ProductWish",
                column: "user_id",
                principalTable: "AspUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AspUser_user_id",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspUser_user_id",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCart_AspUser_user_id",
                table: "ProductCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductWish_AspUser_user_id",
                table: "ProductWish");

            migrationBuilder.DropIndex(
                name: "IX_Address_user_id",
                table: "Address");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    age = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    email = table.Column<string>(type: "varchar(200)", nullable: false),
                    gender = table.Column<string>(type: "varchar(50)", nullable: true),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    role = table.Column<string>(type: "varchar(50)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_user_id",
                table: "Address",
                column: "user_id",
                unique: true,
                filter: "[user_id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_User_user_id",
                table: "Address",
                column: "user_id",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_user_id",
                table: "Order",
                column: "user_id",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCart_User_user_id",
                table: "ProductCart",
                column: "user_id",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWish_User_user_id",
                table: "ProductWish",
                column: "user_id",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
