using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Location
    {
        // ID of Location 
        [Required]
        [Key]
        public int LocationID { get; set; }

        // Address in this sense is Street of Location
        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        // Location Surburb
        [Required]
        [StringLength(25)]
        public string Surburb { get; set; }

        //City of Location 
        [Required]
        [StringLength (50)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]

        // Region of Location
        public string Region { get; set; }

        // Location PostCode 
        [Required]
        [RegularExpression(@"^\d{4}$",ErrorMessage = "Postcode must be 4 digits.")]
        [StringLength(4)]
        public string PostCode { get; set; }

        // This is the country of the location
        [Required]
        [StringLength(50)]
        public string Country { get; set; }
    }
}
