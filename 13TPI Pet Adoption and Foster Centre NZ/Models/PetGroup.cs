using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.Build.Framework;

public class PetGroup
{
    public int PetGroupID { get; set; }
    [Required] public string PetGroupName { get; set; }
    public ICollection<Pet> Pets { get; set; }
    public ICollection<Coordinator> Coordinators { get; set; }
}