using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class AdminOffice
    {
        [Key]// Makes the below property a primary key
        public int AdminID { get; set; }
        // FK → Use
        public int UserID { get; set; }
       

        // First Name of the admin
        [Required]// Field is required
        [StringLength(25, MinimumLength = 2)]// Limits the length between 2 and 25 characters
        public string FirstName { get; set; } = string.Empty;

        //Last Name of the admin
        [Required]//Field is required
        [StringLength(25, MinimumLength = 2)]// Limits the length between 2 and 25 characters
        public string LastName { get; set; } = string.Empty;

        // Email Address of the admin 
        [Required]//Field is required 
        [EmailAddress]// Lets user provide a valid e-mail adddress with a existing provider
        public string EmailAddress { get; set; } = string.Empty;

        // Admin contact number
        [Required] // Field is required
        [RegularExpression(@"^\d{11}$",ErrorMessage ="Contact number must be 11 digits")]
        public string ContactNo { get; set; } = string.Empty;

        // Hire Date of Admin
        [DataType(DataType.Date)]
        public DateTime DateHired { get; set; }

        // Access level of admin
        [Required] // Field is required 
        [StringLength (20)] // Limits the length of adin title between 2 and 25 characters

        //Normalised
        public int AccessLevelID { get; set; }
        public virtual AccessLevel? AccessLevel { get; set; }

        public string LevelName { get; set; }

        public string TitleName { get; set; }
        public virtual int   TitleID {get; set;}
 [Column(TypeName = "nvarchar(100)")]
        
        public string? ImageName { get; set; }
        [NotMapped]
        [DisplayName("Upload Files")]
        public IFormFile? ImageFile { get; set; }
      
    }
}
