using System.ComponentModel.DataAnnotations;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;



    public class Breed
    {

       // BreedID (Primary Key)
       [Key]
       public int BreedID { get; set; }

       // BreedName
       [Required(ErrorMessage = "Breed Name is required")]
       [StringLength(50,MinimumLength = 3, ErrorMessage = "Breed Name must be between 3 and 50 characters.")]
      [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Breed Name can only contain letters and spaces.")]
    public string BreedName { get; set; }
    }

