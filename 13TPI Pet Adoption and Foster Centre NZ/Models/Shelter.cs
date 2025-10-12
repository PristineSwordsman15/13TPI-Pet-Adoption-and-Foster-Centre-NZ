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
        public string ShelterName { get; set; }

        // LocationID (Foreign Key) (references Location table) of Shelter
        [Required]
        public int LocationID { get; set; }
    }
}
