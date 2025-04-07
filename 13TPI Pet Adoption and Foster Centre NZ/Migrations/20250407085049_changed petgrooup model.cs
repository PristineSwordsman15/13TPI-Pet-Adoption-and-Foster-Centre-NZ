using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Migrations
{
    /// <inheritdoc />
    public partial class changedpetgrooupmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MedicalID",
                table: "MedicalRecord",
                newName: "MedicalRecordID");

            migrationBuilder.AlterColumn<string>(
                name: "ShelterName",
                table: "Shelter",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "GroupID",
                table: "PetGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupID",
                table: "PetGroup");

            migrationBuilder.RenameColumn(
                name: "MedicalRecordID",
                table: "MedicalRecord",
                newName: "MedicalID");

            migrationBuilder.AlterColumn<string>(
                name: "ShelterName",
                table: "Shelter",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
