using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class PetStatus
    {
        [Key]
        public int PetStatusID { get; set; }

        [Required, StringLength(25)]
        public string StatusName { get; set; } = string.Empty;

        public ICollection<Pet>? Pets { get; set; }
    }
}
