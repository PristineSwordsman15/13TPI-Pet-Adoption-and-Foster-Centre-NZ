using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class ShelterType
    {
        [Key]
        public int ShelterTypeID { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Shelter>? Shelters { get; set; }
    }
}
