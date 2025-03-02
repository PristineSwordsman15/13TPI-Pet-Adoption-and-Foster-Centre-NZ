using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class AdminOffice
    {
        [Required]
        [Key]
        public int AdminID { get; set; }
        [Required]
        [ForeignKey("UserID")]
        public int UserID { get; set; }
        [Required]
        [StringLength(25,MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25, MinimumLength =2)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [RegularExpression(@"^\d{11}$",ErrorMessage ="Contact number must be 11 digits")]
        public string ContactNo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateHired { get; set; }
        [Required]
        [StringLength (20)]
        public string AccessLevel { get; set; }
        [Required]
        [ForeignKey("RoleID")]
        public int RoleID { get; set; }
    }
}
