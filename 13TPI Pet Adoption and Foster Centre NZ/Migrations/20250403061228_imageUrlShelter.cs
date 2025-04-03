using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Migrations
{
    /// <inheritdoc />
    public partial class imageUrlShelter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageID",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Pet");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Shelter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Shelter");

            migrationBuilder.AddColumn<int>(
                name: "ImageID",
                table: "Pet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Pet",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Pet",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");
        }
    }
}
