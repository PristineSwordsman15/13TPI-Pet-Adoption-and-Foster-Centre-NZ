using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    
    
        public class PetGroup
        {
            [Key]
            public int PetGroupID { get; set; }

            [Required, StringLength(25)]
            public string PetGroupName { get; set; } = string.Empty;

            [Required, StringLength(100)]
            public string PetGroupDescription { get; set; } = string.Empty;

        public int PetID { get; set; } 
        public int GroupID { get; set; }

            public ICollection<Pet>? Pets { get; set; }
        }
    }

