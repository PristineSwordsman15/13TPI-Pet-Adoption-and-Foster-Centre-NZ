using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Migrations
{
    /// <inheritdoc />
    public partial class addingimagestoproject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "ImageID",
                table: "MedicalRecord",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "MedicalRecord",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "MedicalRecord",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PostCode",
                table: "Location",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ImageID",
                table: "Coordinator",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Coordinator",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Coordinator",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ImageID",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "ImageID",
                table: "Coordinator");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Coordinator");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Coordinator");

            migrationBuilder.AlterColumn<string>(
                name: "PostCode",
                table: "Location",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);
        }
    }
}
