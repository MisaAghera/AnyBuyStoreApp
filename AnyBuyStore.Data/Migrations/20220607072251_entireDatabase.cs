using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnyBuyStore.Data.Migrations
{
    public partial class entireDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    house = table.Column<string>(type: "varchar(200)", nullable: false),
                    street = table.Column<string>(type: "varchar(200)", nullable: false),
                    city = table.Column<string>(type: "varchar(200)", nullable: false),
                    state = table.Column<string>(type: "varchar(200)", nullable: false),
                    country = table.Column<string>(type: "varchar(100)", nullable: false),
                    zipcode = table.Column<string>(type: "varchar(30)", nullable: false),
                    address_type = table.Column<string>(type: "varchar(50)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "varchar(100)", nullable: false),
                    value = table.Column<string>(type: "varchar(100)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Is_active = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    email = table.Column<string>(type: "varchar(200)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<string>(type: "varchar(50)", nullable: true),
                    role = table.Column<string>(type: "varchar(50)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSubcategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_category_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSubcategory", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductSubcategory_ProductCategory_Product_category_id",
                        column: x => x.Product_category_id,
                        principalTable: "ProductCategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    total_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total_discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    discount_id = table.Column<int>(type: "int", nullable: false),
                    product_subcategory_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    description = table.Column<string>(type: "varchar(255)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    brand = table.Column<string>(type: "varchar(100)", nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_Discount_discount_id",
                        column: x => x.discount_id,
                        principalTable: "Discount",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductSubcategory_product_subcategory_id",
                        column: x => x.product_subcategory_id,
                        principalTable: "ProductSubcategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    delivery_address_id = table.Column<int>(type: "int", nullable: false),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    discount_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "varchar(50)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Address_delivery_address_id",
                        column: x => x.delivery_address_id,
                        principalTable: "Address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Discount_discount_id",
                        column: x => x.discount_id,
                        principalTable: "Discount",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Order_order_id",
                        column: x => x.order_id,
                        principalTable: "Order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Product_product_id",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProductCart",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    is_available = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCart", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductCart_Product_product_id",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCart_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductWish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductWish_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWish_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_user_id",
                table: "Order",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_delivery_address_id",
                table: "OrderDetails",
                column: "delivery_address_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_discount_id",
                table: "OrderDetails",
                column: "discount_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_order_id",
                table: "OrderDetails",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_product_id",
                table: "OrderDetails",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_discount_id",
                table: "Product",
                column: "discount_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_product_subcategory_id",
                table: "Product",
                column: "product_subcategory_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCart_product_id",
                table: "ProductCart",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCart_user_id",
                table: "ProductCart",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSubcategory_Product_category_id",
                table: "ProductSubcategory",
                column: "Product_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWish_ProductId",
                table: "ProductWish",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWish_UserId",
                table: "ProductWish",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductCart");

            migrationBuilder.DropTable(
                name: "ProductWish");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "ProductSubcategory");

            migrationBuilder.DropTable(
                name: "ProductCategory");
        }
    }
}
