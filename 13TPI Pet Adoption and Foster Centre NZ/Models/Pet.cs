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
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Pet Name must be between 2 and 50 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Pet Name can only contain letters and spaces.")]
        public string PetName { get; set; }

        // ShelterID (Foreign Key) (references Shelter table), regarding which shelter the pet is in
        [Required]
        [Display(Name = "ShelterID")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid shelter.")]
        public int ShelterID { get; set; }
        public Shelter Shelter { get; set; }

        // BreedID (Foreign Key) (references Breed table) of pet
        [Required]
        [Display(Name = "BreedID")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid breed.")]
        public int BreedID { get; set; }
        public Breed Breed { get; set; }

        // Colour of pet
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Colour must be between 3 and 30 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Colour can only contain letters and spaces.")]
        [Display(Name = "Colour")]
        public string Colour { get; set; }

        // Checks if pet is adopted
        [Required]
        [RegularExpression(@"^(true|false)$", ErrorMessage = "Adoption must be true or false.")]
        [Display(Name = "Adopted")]
        public bool Adoption { get; set; }

    }
}
