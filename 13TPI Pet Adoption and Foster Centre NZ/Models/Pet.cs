using System.ComponentModel.DataAnnotations;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Pet
    {
        // PetID (Primary Key) 
        [Key]
        public int PetID { get; set; }

        //Name of pet
        [Required]
        public string PetName { get; set; }

        // ShelterID (Foreign Key) (references Shelter table), regarding which shelter the pet is in
        [Required]
        public int ShelterID { get; set; }
        public Shelter Shelter { get; set; }

        // BreedID (Foreign Key) (references Breed table) of pet
        [Required]
        public int BreedID { get; set; }
        public Breed Breed { get; set; }

        // Colour of pet
        [Required]
        public string Colour { get; set; }

        // Checks if pet is adopted
        [Required]
        public bool Adoption { get; set; }

    }
}
