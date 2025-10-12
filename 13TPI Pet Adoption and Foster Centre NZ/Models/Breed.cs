using System.ComponentModel.DataAnnotations;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;



    public class Breed
    {
    // BreedID (Primary Key)
    [Key]
       public int BreedID { get; set; }

    // BreedName
    [Required]
       public string BreedName { get; set; }
    }

