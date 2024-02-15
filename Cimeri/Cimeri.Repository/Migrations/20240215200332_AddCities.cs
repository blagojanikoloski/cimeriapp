using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cimeri.Repository.Migrations
{
    public partial class AddCities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityName" },
                values: new object[,]
                {
                    { 1, "Скопје" },
                    { 2, "Битола" },
                    { 3, "Куманово" },
                    { 4, "Прилеп" },
                    { 5, "Тетово" },
                    { 6, "Велес" },
                    { 7, "Штип" },
                    { 8, "Охрид" },
                    { 9, "Гостивар" },
                    { 10, "Струмица" },
                    { 11, "Кавадарци" },
                    { 12, "Кочани" },
                    { 13, "Кичево" },
                    { 14, "Струга" },
                    { 15, "Радовиш" },
                    { 16, "Гевгелија" },
                    { 17, "Дебар" },
                    { 18, "Крива Паланка" },
                    { 19, "Свети Николе" },
                    { 20, "Неготино" },
                    { 21, "Делчево" },
                    { 22, "Виница" },
                    { 23, "Ресен" },
                    { 24, "Пробиштип" },
                    { 25, "Берово" },
                    { 26, "Кратово" },
                    { 27, "Богданци" },
                    { 28, "Крушево" },
                    { 29, "Македонска Каменица" },
                    { 30, "Валандово" },
                    { 31, "Македонски Брод" },
                    { 32, "Демир Капија" },
                    { 33, "Пехчево" },
                    { 34, "Демир Хисар" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityID",
                keyValue: 34);
        }
    }
}
