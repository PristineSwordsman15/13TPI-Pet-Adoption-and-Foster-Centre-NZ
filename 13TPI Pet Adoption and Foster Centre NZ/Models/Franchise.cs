using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Franchise
    {
        // ID of Franchise
        [Required]
        [Key]
        public int FranchiseID { get; set; }
        //Name of Franchise
        [Required]
        [StringLength(50)]
        public string FranchiseName { get; set; }
        // Contact No for Franchise 11 digit max
        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Contact number must be 11 digits")]
        public string ContactNo { get; set; }

        //This is foreign key for Location
        [Required]
        [ForeignKey("LocationID")]
        public int LocationID { get; set; }

        // Franchise Email Address
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        // Operating hours of franchise
        [Required]
        [StringLength(25)]
        public string OperatingHours { get; set; }

        // ID of Owner running shelter 
        
        public int OwnerID { get; set; }

    }
}
