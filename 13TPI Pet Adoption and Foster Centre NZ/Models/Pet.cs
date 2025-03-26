using System;
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
        public int ImageID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }

    }
}
