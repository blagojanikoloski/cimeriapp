using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cimeri.Repository.Migrations
{
    public partial class CreateCimeriPostAndMusic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CimeriPost",
                columns: table => new
                {
                    CimeriPostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    budget = table.Column<int>(type: "int", nullable: false),
                    sameGenderRequired = table.Column<bool>(type: "bit", nullable: false),
                    studentRequired = table.Column<bool>(type: "bit", nullable: false),
                    optimalNumberOfRoommates = table.Column<int>(type: "int", nullable: false),
                    howLong = table.Column<int>(type: "int", nullable: false),
                    isSmoker = table.Column<bool>(type: "bit", nullable: false),
                    guestsAllowed = table.Column<bool>(type: "bit", nullable: false),
                    music = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CimeriPost", x => x.CimeriPostID);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "Music",
                columns: table => new
                {
                    MusicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music", x => x.MusicID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CimeriPost");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Music");
        }
    }
}
