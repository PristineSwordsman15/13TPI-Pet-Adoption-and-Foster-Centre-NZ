using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Coordinator
    {
        // Primary key 
        [Required]
        [Key]
        public int CoordinatorID { get; set; }
        [Required]
        [ForeignKey("FranchiseID")]
        public int FranchiseID { get; set; }
        [Required]
        [ForeignKey("PetGroupID")]
        public int PetGroupID { get; set; }
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Contact number must be 11 digits")]
        public string ContactNo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        [Required]
        [StringLength(30)]
        public string ExperienceLevel { get; set; } 

     [Required]
     [Url]
    public string ProfileImageUrl { get; set; }
    }
}
