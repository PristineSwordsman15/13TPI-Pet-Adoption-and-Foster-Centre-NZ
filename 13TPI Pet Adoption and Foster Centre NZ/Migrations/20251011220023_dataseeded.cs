using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Migrations
{
    /// <inheritdoc />
    public partial class dataseeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Breed",
                columns: new[] { "BreedID", "BreedName" },
                values: new object[,]
                {
                    { 1, "Appetizer" },
                    { 2, "Main" },
                    { 3, "Dalmation" },
                    { 4, "German Shepard" },
                    { 5, "Labrador" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "LocationID", "City", "Country", "LocationName", "State", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Auckland", "NZ", "Central City", "Auckland", "123 Main St", "1010" },
                    { 2, "Auckland", "NZ", "Northside", "Auckland", "456 North Rd", "1021" },
                    { 3, "Auckland", "NZ", "East End", "Auckland", "789 East Ave", "1032" },
                    { 4, "Auckland", "NZ", "South Park", "Auckland", "321 South St", "1043" },
                    { 5, "Auckland", "NZ", "Westfield", "Auckland", "654 West Rd", "1054" }
                });

            migrationBuilder.InsertData(
                table: "Shelter",
                columns: new[] { "ShelterID", "LocationID", "ShelterName" },
                values: new object[,]
                {
                    { 1, 1, "Happy Tails Shelter" },
                    { 2, 2, "Paws and Claws Rescue" },
                    { 3, 3, "Furry Friends Haven" },
                    { 4, 4, "Safe Haven Shelter" },
                    { 5, 5, "Wagging Tails Rescue" },
                    { 6, 4, "Cozy Paws Shelter" },
                    { 7, 3, "Loving Arms Rescue" },
                    { 8, 2, "Forever Home Shelter" },
                    { 9, 1, "New Beginnings Rescue" },
                    { 10, 5, "Caring Hearts Shelter" }
                });

            migrationBuilder.InsertData(
                table: "Pet",
                columns: new[] { "PetID", "Adoption", "BreedID", "Colour", "PetName", "ShelterID" },
                values: new object[,]
                {
                    { 1, false, 1, "Brown", "Max", 1 },
                    { 2, false, 2, "Black", "Bella", 2 },
                    { 3, false, 1, "White", "Charlie", 1 },
                    { 4, false, 3, "Golden", "Lucy", 3 },
                    { 5, false, 3, "Golden", "Walter", 4 },
                    { 6, false, 2, "Orange", "Carlos", 2 },
                    { 7, false, 3, "Yellow", "Michael", 5 },
                    { 8, false, 5, "Brown", "Oscar", 4 },
                    { 9, false, 3, "Black", "Fred", 1 },
                    { 10, false, 5, "Tan", "Lucas", 2 },
                    { 11, false, 3, "White", "Alonso", 3 },
                    { 12, false, 1, "Grey", "Alex", 5 },
                    { 13, false, 4, "Red", "Lawrence", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pet_BreedID",
                table: "Pet",
                column: "BreedID");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_ShelterID",
                table: "Pet",
                column: "ShelterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Breed_BreedID",
                table: "Pet",
                column: "BreedID",
                principalTable: "Breed",
                principalColumn: "BreedID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Shelter_ShelterID",
                table: "Pet",
                column: "ShelterID",
                principalTable: "Shelter",
                principalColumn: "ShelterID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Breed_BreedID",
                table: "Pet");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Shelter_ShelterID",
                table: "Pet");

            migrationBuilder.DropIndex(
                name: "IX_Pet_BreedID",
                table: "Pet");

            migrationBuilder.DropIndex(
                name: "IX_Pet_ShelterID",
                table: "Pet");

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "LocationID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "LocationID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "LocationID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "LocationID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "LocationID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pet",
                keyColumn: "PetID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pet",
                keyColumn: "PetID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pet",
                keyColumn: "PetID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pet",
                keyColumn: "PetID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pet",
                keyColumn: "PetID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pet",
                keyColumn: "PetID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pet",
                keyColumn: "PetID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pet",
                keyColumn: "PetID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pet",
                keyColumn: "PetID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pet",
                keyColumn: "PetID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pet",
                keyColumn: "PetID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pet",
                keyColumn: "PetID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Pet",
                keyColumn: "PetID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Shelter",
                keyColumn: "ShelterID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Shelter",
                keyColumn: "ShelterID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Shelter",
                keyColumn: "ShelterID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Shelter",
                keyColumn: "ShelterID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Breed",
                keyColumn: "BreedID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Breed",
                keyColumn: "BreedID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Breed",
                keyColumn: "BreedID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Breed",
                keyColumn: "BreedID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Breed",
                keyColumn: "BreedID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Shelter",
                keyColumn: "ShelterID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shelter",
                keyColumn: "ShelterID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shelter",
                keyColumn: "ShelterID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shelter",
                keyColumn: "ShelterID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Shelter",
                keyColumn: "ShelterID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Shelter",
                keyColumn: "ShelterID",
                keyValue: 10);
        }
    }
}
