using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Location
    {
        // ID of Location 
        [Key]
        public int LocationID { get; set; }

        // Address in this sense is Street of Location
        [Required]
        [StringLength(150)]
        public string Address { get; set; } = string.Empty;

        // Location Surburb
        [Required]
        [StringLength(25)]
        public string Surburb { get; set; } = string.Empty;

        //City of Location 
        [Required]
        [StringLength(50)]
        public string City { get; set; } = string.Empty;

        // Region of Location
        [Required]
        [StringLength(50)]
        public string Region { get; set; } = string.Empty;

        // Location PostCode 
        [Required]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Postcode must be 4 digits.")]
        [StringLength(4)]
        public string PostCode { get; set; } = string.Empty;

        // This is the country of the location
        [Required]
        [StringLength(50)]
        public string Country { get; set; } = string.Empty;


        public ICollection<Franchise> Franchises { get; set; }
        public ICollection<Shelter> Shelters { get; set; }
    }
}
