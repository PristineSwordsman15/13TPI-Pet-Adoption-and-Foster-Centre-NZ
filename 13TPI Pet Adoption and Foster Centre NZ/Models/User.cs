using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class User
    {
        [Required]
        [Key]
        public int UserID { get; set; }
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
        [StringLength(25,MinimumLength = 8, ErrorMessage = "Password must have a minimum length of 8 characters, with atleast 1 uppercase letter, 1 lowercase letter, a symbol and a numerical value")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^\d(11)$", ErrorMessage = "Contact number must be 11 digits")]
        public string ContactNo { get; set; }
        [Required]
        [ForeignKey("`LocationID")]
        public int LocationID { get; set; }
        [Required]
        [ForeignKey("RoleID")]
        public int RoleID { get; set; }
        public int? FranchiseID { get; set; } // Nullable as not all user users will be a franchise owner 
        [Url]
        public string ProfileImageUrl { get; set; }

    }
}
