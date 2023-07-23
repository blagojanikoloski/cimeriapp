using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cimeri.Repository.Migrations
{
    public partial class AddCityIDToCimeriPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "CimeriPost",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityID",
                table: "CimeriPost");
        }
    }
}
