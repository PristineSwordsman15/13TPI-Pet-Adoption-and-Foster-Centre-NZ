using System.ComponentModel.DataAnnotations;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Shelter
    {

        [Key]
        public int ShelterID { get; set; }

        [Required]
        public string ShelterName { get; set; }

        [Required]
        public int LocationID { get; set; }
    }
}
