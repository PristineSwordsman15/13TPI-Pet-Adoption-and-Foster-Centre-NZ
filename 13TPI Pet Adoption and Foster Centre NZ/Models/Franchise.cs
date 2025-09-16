using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;

public class Franchise
{
    public int FranchiseID { get; set; }
    
    public string FranchiseName { get; set; }

    // FK
    public int LocationID { get; set; }
    public Location Location { get; set; }

    public ICollection<Coordinator> Coordinators { get; set; }
    public ICollection<Shelter> Shelters { get; set; }
}