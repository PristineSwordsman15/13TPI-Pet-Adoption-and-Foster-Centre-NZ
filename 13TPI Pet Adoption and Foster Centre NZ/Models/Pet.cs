using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Pet
    {

        [Key]
        public int PetID { get; set; }
        [Required]
        [StringLength(50)]
        public string PetName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]

        public int PetGroupID { get; set; }
        public virtual PetGroup? PetGroupNamw { get; set; }
        [Required]
        [StringLength(50)]
        public string Species { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Breed { get; set; } = string.Empty;
        [Required]
        public int PetAge { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        //Normalised -. PetStatus Lookup

        public int PetStatusID { get; set; } // Adopted, Fostered, Available
        public virtual PetStatus? PetStatus { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [NotMapped]
        [DisplayName("Image Name")]
        
        public string? ImageName { get; set; }

        [NotMapped, DisplayName("Upload File")]
        public IFormFile? ImageFile { get; set; }
    }
}
