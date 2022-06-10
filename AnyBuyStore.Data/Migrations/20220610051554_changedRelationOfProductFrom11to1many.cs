using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnyBuyStore.Data.Migrations
{
    public partial class changedRelationOfProductFrom11to1many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_product_subcategory_id",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_product_subcategory_id",
                table: "Product",
                column: "product_subcategory_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_product_subcategory_id",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_product_subcategory_id",
                table: "Product",
                column: "product_subcategory_id",
                unique: true);
        }
    }
}
