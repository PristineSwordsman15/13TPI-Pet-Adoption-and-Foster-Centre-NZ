using System.ComponentModel.DataAnnotations;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Location
    {
        // LocationID (Primary Key)
        [Key]
        public int LocationID { get; set; }

        // Name of location in which shelters are located
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Location Name must be between 3 and 100 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Location Name can only contain letters and spaces.")]
        public string LocationName { get; set; }

        // Street address of location
        [Required]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Street address must be between 5 and 200 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s,.-]+$", ErrorMessage = "Street address can only contain letters, numbers, spaces, commas,and hyphens.")]
        public string Street { get; set; }

        // Location city
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "City name must be between 2 and 100 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City name can only contain letters and spaces.")]
        public string City { get; set; }

        // Location region/state
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "State name must be between 2 and 100 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "State name can only contain letters and spaces.")]
        public string State { get; set; }

        // Location zip code
        [Required]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "Zip Code must be between 4 and 6 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s-]+$", ErrorMessage = "Zip Code can only contain letters, numbers, and hyphens.")]
        public string ZipCode { get; set; }

        // Location country
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Country name must be between 2 and 100 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Country name can only contain letters and spaces.")]
        public string Country { get; set; }
    }
}
