using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Pet
    {
        [Required]
        [Key]   
        public int PetID { get; set; }
        [Required]
        [StringLength(50)]
        public string PetName { get; set; }
        [Required]
        [StringLength(50)]
        public string  PetGroupName { get; set;}
        [Required]
        [StringLength(50)]
        public string Species { get; set; }
        [Required]
        [StringLength(50)]
        public string Breed { get; set; }
        [Required]  
        public int PetAge { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
        [Required]
        public string PetStatus { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Title { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [NotMapped]
        [DisplayName("Image Name")]
        public string? ImageName { get; set; }
        [NotMapped]
        [DisplayName("Upload Files")]
        public IFormFile? ImageFile { get; set; }

    }
}
