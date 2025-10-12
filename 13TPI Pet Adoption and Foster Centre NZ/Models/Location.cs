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
        public string LocationName { get; set; }

        // Street address of location
        [Required]
        public string Street { get; set; }

        // Location city
        [Required]
        public string City { get; set; }

        // Location region/state
        [Required]
        public string State { get; set; }

        // Location zip code
        [Required]
        public string ZipCode { get; set; }

        // Location country
        [Required]
        public string Country { get; set; }
    }
}
