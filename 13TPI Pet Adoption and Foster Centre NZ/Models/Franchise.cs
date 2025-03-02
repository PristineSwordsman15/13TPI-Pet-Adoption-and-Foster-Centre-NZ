using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Franchise
    {
        [Required]
        [Key]
        public int FranchiseID { get; set; }
        [Required]
        [StringLength(50)]
        public string FranchiseName { get; set; }
        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Contact number must be 11 digits")]
        public string ContactNo { get; set; }
        [Required]
        [ForeignKey("LocationID")]
        public int LocationID { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [StringLength(25)]
        public string OperatingHours { get; set; }
        public int OwnerID { get; set; }

    }
}
