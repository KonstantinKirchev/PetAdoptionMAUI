using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetAdoption.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hash",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "Users",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "Salt");

            migrationBuilder.AddColumn<string>(
                name: "Hash",
                table: "Users",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");
        }
    }
}
