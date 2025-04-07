using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class PetGroup
    {
        // ID of PetGroup, pet belongs to
        [Required]
        [Key]
        public int PetGroupID { get; set; }
        //ID of pet
        [Required]
        [ForeignKey("Pet")]
        public int PetID { get; set;}

        // Group ID of which group pet belongs to 
        [Required]
        public int GroupID { get; set; }
        // Name of PetGroup
        public string PetGroupName { get; set; }
        // Description of PetGroup
        public string PeGroupDescriptiom { get; set; }
    }
}
