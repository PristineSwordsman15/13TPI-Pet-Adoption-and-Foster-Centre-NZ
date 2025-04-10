using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Migrations
{
    /// <inheritdoc />
    public partial class subbedpgidtopgnameinpets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PetGroupID",
                table: "Pet",
                newName: "PetGroupName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PetGroupName",
                table: "Pet",
                newName: "PetGroupID");
        }
    }
}
