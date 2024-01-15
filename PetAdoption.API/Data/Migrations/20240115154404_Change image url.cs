using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetAdoption.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changeimageurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "img_1.jpg");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "img_2.jpg");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "img_3.jpg");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "img_4.jpg");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "img_5.jpg");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "img_6.jpg");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "img_7.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU");
        }
    }
}
