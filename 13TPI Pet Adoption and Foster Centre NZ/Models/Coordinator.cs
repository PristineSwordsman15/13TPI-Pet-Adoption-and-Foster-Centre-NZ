using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Coordinator
    {
        [Key]
        public int CoordinatorID { get; set; }

        [Required]
        public int FranchiseID { get; set; }
        public Franchise Franchise { get; set; }

        [Required]
        public int PetGroupID { get; set; }
        public PetGroup PetGroup { get; set; }

        [Required, StringLength(25, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required, StringLength(25, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public string EmailAddress { get; set; }

        [Required, RegularExpression(@"^\d{9,11}$", ErrorMessage = "Contact number must be 9–11 digits")]
        public string ContactNo { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [Required, StringLength(30)]
        public string ExperienceLevel { get; set; } // Could be normalized

        [Column(TypeName = "nvarchar(50)")]
        public string? Title { get; set; }

        [NotMapped]
        [DisplayName("Image Name")]
        public string? ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload Files")]
        public IFormFile? ImageFile { get; set; }
    }
}