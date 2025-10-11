using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Migrations
{
    /// <inheritdoc />
    public partial class changedtwobreedrecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Breed",
                keyColumn: "BreedID",
                keyValue: 1,
                column: "BreedName",
                value: "Shit Tzu");

            migrationBuilder.UpdateData(
                table: "Breed",
                keyColumn: "BreedID",
                keyValue: 2,
                column: "BreedName",
                value: "Chihuahua");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Breed",
                keyColumn: "BreedID",
                keyValue: 1,
                column: "BreedName",
                value: "Appetizer");

            migrationBuilder.UpdateData(
                table: "Breed",
                keyColumn: "BreedID",
                keyValue: 2,
                column: "BreedName",
                value: "Main");
        }
    }
}
