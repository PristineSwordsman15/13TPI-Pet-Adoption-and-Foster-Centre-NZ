using System.ComponentModel.DataAnnotations;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Shelter
    {
        // ShelterID (Primary Key)
        [Key]
        public int ShelterID { get; set; }


        // Name of shelter
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Shelter Name must be between 3 and 100 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Shelter Name can only contain letters and spaces.")]
        [Display(Name = "Shelter Name")]
        public string ShelterName { get; set; }

        // LocationID (Foreign Key) (references Location table) of Shelter
        [Required]
        [Display(Name = "LocationID")]
        public int LocationID { get; set; } 
        public Location Location { get; set; }
    }
}
