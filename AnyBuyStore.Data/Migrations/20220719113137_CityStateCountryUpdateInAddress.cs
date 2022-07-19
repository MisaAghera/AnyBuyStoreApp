using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnyBuyStore.Data.Migrations
{
    public partial class CityStateCountryUpdateInAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "city",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "country",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "state",
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

            migrationBuilder.AddColumn<int>(
                name: "city_id",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "country_id",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "state_id",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "city_id",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "country_id",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "state_id",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "Address",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "Address",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "state",
                table: "Address",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");
        }
    }
}
