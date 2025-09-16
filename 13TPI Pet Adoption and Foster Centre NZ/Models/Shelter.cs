using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using System.ComponentModel.DataAnnotations;

public class Shelter
{
    public int ShelterID { get; set; }
    [Required] public string Name { get; set; }

    // FKs
    public int FranchiseID { get; set; }
    public Franchise Franchise { get; set; }

    public int LocationID { get; set; }
    public Location Location { get; set; }

    public int ShelterTypeID { get; set; }
    public ShelterType ShelterType { get; set; }
}