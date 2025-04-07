using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Coordinator
    {
        //Unique identifier for the coordinator 
        [Required]
        [Key]
        public int CoordinatorID { get; set; }
        //Associated franchise (FK)
        [Required]
        [ForeignKey("FranchiseID")]
        public int FranchiseID { get; set; }
        //Associated pet group (FK)
        [Required]
        [ForeignKey("PetGroupID")]
        public int PetGroupID { get; set; }
        [Required]
        [StringLength(25)]
        // First Name of Coordinator
        public string FirstName { get; set; }
        [Required]
        [StringLength(25)]

        //Last Name of Coordinator
        public string LastName { get; set; }

        // Coordinator Email Address
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        // Coordinator Contact No (11 digits)
        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Contact number must be 11 digits")]
        public string ContactNo { get; set; }
       
        // Hire Date 
        [Required]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        //Experience level of coordinator
        [Required]
        [StringLength(30)]
        public string ExperienceLevel { get; set; }

        // Proffesional Title 
        [Column(TypeName = "nvarchar(50)")]
        public string? Title { get; set; }

        // File name of uploaded profile image (not mapped to DB)
        [Column(TypeName = "nvarchar(100)")]
        [NotMapped]
        [DisplayName("Image Name")]
        public string? ImageName { get; set; }

        // Uploaded image file (not mapped to DB)
        [NotMapped]
        [DisplayName("Upload Files")]
        public IFormFile? ImageFile { get; set; } 
    }
}
