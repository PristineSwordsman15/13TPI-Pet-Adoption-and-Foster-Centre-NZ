using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Migrations
{
    /// <inheritdoc />
    public partial class newfieldsinmodelsforimageindb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Shelter");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "Coordinator");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Shelter",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Pet",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Coordinator",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AdminOffice",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Shelter");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Coordinator");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AdminOffice");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Shelter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Pet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "Coordinator",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
