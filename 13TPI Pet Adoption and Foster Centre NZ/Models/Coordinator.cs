using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Coordinator
    {
        public int CoordinatorID { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }

        // FK
        public int FranchiseID { get; set; }
        public Franchise Franchise { get; set; }

        public int PetGroupID { get; set; }
        public PetGroup PetGroup { get; set; }
    }
}
