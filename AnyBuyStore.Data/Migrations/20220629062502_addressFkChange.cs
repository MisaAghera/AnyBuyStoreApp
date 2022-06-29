using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnyBuyStore.Data.Migrations
{
    public partial class addressFkChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_OrderDetails_orderDetails_id",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "orderDetails_id",
                table: "Address",
                newName: "order_id");

            migrationBuilder.RenameIndex(
                name: "IX_Address_orderDetails_id",
                table: "Address",
                newName: "IX_Address_order_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Order_order_id",
                table: "Address",
                column: "order_id",
                principalTable: "Order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Order_order_id",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "Address",
                newName: "orderDetails_id");

            migrationBuilder.RenameIndex(
                name: "IX_Address_order_id",
                table: "Address",
                newName: "IX_Address_orderDetails_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_OrderDetails_orderDetails_id",
                table: "Address",
                column: "orderDetails_id",
                principalTable: "OrderDetails",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
