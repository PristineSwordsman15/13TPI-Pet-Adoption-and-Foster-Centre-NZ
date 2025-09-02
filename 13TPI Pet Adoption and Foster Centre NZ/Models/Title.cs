using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Title
    {
        [Key]
        public int TitleID { get; set; }

        [Required, StringLength(50)]
        public string TitleName { get; set; } = string.Empty;

        public ICollection<AdminOffice>? Admins { get; set; }
    }
}
