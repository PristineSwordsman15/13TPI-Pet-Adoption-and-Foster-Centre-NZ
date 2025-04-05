using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Pet
    {
        public int PetID { get; set; }
        public string PetName { get; set; }
        public int  PetGroupID { get; set;}
        public string Species { get; set; }
        public string Breed { get; set; }
        public int PetAge { get; set; }
        public DateTime ArrivalDate { get; set; }
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
