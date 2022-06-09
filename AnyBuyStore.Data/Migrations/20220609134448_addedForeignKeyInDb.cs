using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnyBuyStore.Data.Migrations
{
    public partial class addedForeignKeyInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Address_delivery_address_id",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_delivery_address_id",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "delivery_address_id",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "orderDetails_id",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_orderDetails_id",
                table: "Address",
                column: "orderDetails_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_user_id",
                table: "Address",
                column: "user_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_OrderDetails_orderDetails_id",
                table: "Address",
                column: "orderDetails_id",
                principalTable: "OrderDetails",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_User_user_id",
                table: "Address",
                column: "user_id",
                principalTable: "User",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_OrderDetails_orderDetails_id",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_User_user_id",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_orderDetails_id",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_user_id",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "orderDetails_id",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Address");

            migrationBuilder.AddColumn<int>(
                name: "delivery_address_id",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_delivery_address_id",
                table: "OrderDetails",
                column: "delivery_address_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Address_delivery_address_id",
                table: "OrderDetails",
                column: "delivery_address_id",
                principalTable: "Address",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
