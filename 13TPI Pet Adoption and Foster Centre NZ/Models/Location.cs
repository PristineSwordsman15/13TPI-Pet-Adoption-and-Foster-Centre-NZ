using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Location
    {
        [Required]
        [Key]
        public int LocationID { get; set; }
        [Required]
        [StringLength(150)]
        public string Address { get; set; }
        [Required]
        [StringLength(25)]
        public string Surburb { get; set; }
        [Required]
        [StringLength (50)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string Region { get; set; }
        [Required]
        [RegularExpression(@"^\d(4)$",ErrorMessage = "Postcode must be 4 digits.")]
        [StringLength(4)]
        public string PostCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Country { get; set; }
    }
}
