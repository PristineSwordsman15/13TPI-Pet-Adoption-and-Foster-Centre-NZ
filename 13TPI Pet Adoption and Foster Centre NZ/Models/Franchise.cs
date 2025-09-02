using Microsoft.AspNet.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Franchise
    {
        // ID of Franchise
        [Key]
        public int FranchiseID { get; set; }
        //Name of Franchise
        [Required]
        [StringLength(50)]
        public string FranchiseName { get; set; } = string.Empty;
        // Contact No for Franchise 11 digit max
        [Required]
        [RegularExpression(@"^\d{9,11}$", ErrorMessage = "Contact number must be between 9 and 11  digits")]
        public string ContactNo { get; set; }

        //This is foreign key for Location
        public int LocationID { get; set; }
        public virtual Location? Location { get; set; }

        // Franchise Email Address
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;

        // Operating hours of franchise
        [Required]
        [StringLength(25)]
        public string OperatingHours { get; set; } = string.Empty;

        // ID of Owner running shelter 
        
        public int OwnerID { get; set; }
        
    }
}
