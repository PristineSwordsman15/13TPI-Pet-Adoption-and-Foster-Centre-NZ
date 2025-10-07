using System.ComponentModel.DataAnnotations;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        [Required]
        public string LocationName { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
