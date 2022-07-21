using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnyBuyStore.Data.Migrations
{
    public partial class removedTotalDiscountFromOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total_discount",
                table: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "total_discount",
                table: "Order",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
