using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnyBuyStore.Data.Migrations
{
    public partial class MinorChangeInAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Cities_CitiesId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Countries_CountriesId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_States_StatesId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_CitiesId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_CountriesId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_StatesId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CitiesId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CountriesId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "StatesId",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Address_city_id",
                table: "Address",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_Address_country_id",
                table: "Address",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_Address_state_id",
                table: "Address",
                column: "state_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Cities_city_id",
                table: "Address",
                column: "city_id",
                principalTable: "Cities",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Countries_country_id",
                table: "Address",
                column: "country_id",
                principalTable: "Countries",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_States_state_id",
                table: "Address",
                column: "state_id",
                principalTable: "States",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Cities_city_id",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Countries_country_id",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_States_state_id",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_city_id",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_country_id",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_state_id",
                table: "Address");

            migrationBuilder.AddColumn<int>(
                name: "CitiesId",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountriesId",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatesId",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_CitiesId",
                table: "Address",
                column: "CitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountriesId",
                table: "Address",
                column: "CountriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StatesId",
                table: "Address",
                column: "StatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Cities_CitiesId",
                table: "Address",
                column: "CitiesId",
                principalTable: "Cities",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Countries_CountriesId",
                table: "Address",
                column: "CountriesId",
                principalTable: "Countries",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_States_StatesId",
                table: "Address",
                column: "StatesId",
                principalTable: "States",
                principalColumn: "id");
        }
    }
}
