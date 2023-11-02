using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetAdoption.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false),
                    AdoptionStatus = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Hash = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAdoptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    AdoptedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdoptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAdoptions_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAdoptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => new { x.UserId, x.PetId });
                    table.ForeignKey(
                        name: "FK_UserFavorites_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "AdoptionStatus", "Breed", "DateOfBirth", "Description", "Gender", "Image", "IsActive", "Name", "Price", "Views" },
                values: new object[,]
                {
                    { 1, 1, "Dog - Golden Retriever", new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Buddy is a friendly and playful Golden Retriever, known for being great with kids", 0, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU", true, "Buddy", 300.0, 0 },
                    { 2, 1, "Cat - Siamese", new DateTime(2021, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Whiskers is an elegant Siamese cat.", 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU", true, "Whiskers", 150.0, 2 },
                    { 3, 1, "Dog - German Shapherd", new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rocky is a friendly and playful German Shapherd, known for being great with kids", 0, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU", true, "Rocky", 400.0, 3 },
                    { 4, 1, "Rabbit - Himalayan", new DateTime(2021, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luna is a friendly and playful Rabbit, known for being great with kids", 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU", true, "Luna", 100.0, 1 },
                    { 5, 2, "Dog - Jack Russel", new DateTime(2019, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jack is an elegant Jack Russel dog, known for being great with kids.", 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU", false, "Jack", 650.0, 2 },
                    { 6, 0, "Cat - Maias", new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maia is a friendly and playful Maias cat, known for being great with kids", 0, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU", true, "Maia", 550.0, 10 },
                    { 7, 1, "Rabbit - Himalayan", new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Raffy is a friendly and playful Rabbit, known for being great with kids", 0, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU", false, "Raffy", 150.0, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAdoptions_PetId",
                table: "UserAdoptions",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdoptions_UserId",
                table: "UserAdoptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_PetId",
                table: "UserFavorites",
                column: "PetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAdoptions");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
