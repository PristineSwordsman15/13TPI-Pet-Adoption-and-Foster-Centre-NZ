using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Shelter
    {
        [Key]
        public int ShelterID { get; set; }

        [Required, StringLength(50)]
        public string ShelterName { get; set; } = string.Empty;

        // FK → Franchise
        public int FranchiseID { get; set; }
        public virtual Franchise? Franchise { get; set; }

        // FK → Location
        public int LocationID { get; set; }
        public virtual Location? Location { get; set; }

        [Required]
        public int AvailableBeds { get; set; }

        [Required]
        public int OccupiedBeds { get; set; }

        [Required, RegularExpression(@"^\d{11}$", ErrorMessage = "Contact number must be 11 digits")]
        public string ContactNo { get; set; } = string.Empty;

        [Required, StringLength(25)]
        public string OperatingHours { get; set; } = string.Empty;

        // Normalized → ShelterType Lookup
        public int ShelterTypeID { get; set; }
        public virtual ShelterType? ShelterType { get; set; }

        [EmailAddress]
        public string? EmailAddress { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? ImageName { get; set; }

        [NotMapped, DisplayName("Upload File")]
        public IFormFile? ImageFile { get; set; }
    }
}
