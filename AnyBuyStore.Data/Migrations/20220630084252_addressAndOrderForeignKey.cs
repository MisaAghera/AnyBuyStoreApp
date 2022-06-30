using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnyBuyStore.Data.Migrations
{
    public partial class addressAndOrderForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Order_order_id",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_order_id",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "order_id",
                table: "Address");

            migrationBuilder.AddColumn<int>(
                name: "address_id",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_address_id",
                table: "Order",
                column: "address_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Address_address_id",
                table: "Order",
                column: "address_id",
                principalTable: "Address",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Address_address_id",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_address_id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "address_id",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "order_id",
                table: "Address",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Address_order_id",
                table: "Address",
                column: "order_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Order_order_id",
                table: "Address",
                column: "order_id",
                principalTable: "Order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
