using System.ComponentModel.DataAnnotations;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Pet
    {
        [Key]
        public int PetID { get; set; }

        [Required]
        public string PetName { get; set; }

        [Required]
        public int ShelterID { get; set; }

        [Required]
        public int BreedID { get; set; }

        [Required]
        public string Colour { get; set; }

        [Required]
        public bool Adoption { get; set; }

    }
}
