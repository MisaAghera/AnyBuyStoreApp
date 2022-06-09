using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnyBuyStore.Data.Migrations
{
    public partial class addDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductWish_User_User_id",
                table: "ProductWish");

            migrationBuilder.RenameColumn(
                name: "User_id",
                table: "ProductWish",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductWish_User_id",
                table: "ProductWish",
                newName: "IX_ProductWish_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWish_User_user_id",
                table: "ProductWish",
                column: "user_id",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductWish_User_user_id",
                table: "ProductWish");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "ProductWish",
                newName: "User_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductWish_user_id",
                table: "ProductWish",
                newName: "IX_ProductWish_User_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductWish_User_User_id",
                table: "ProductWish",
                column: "User_id",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
