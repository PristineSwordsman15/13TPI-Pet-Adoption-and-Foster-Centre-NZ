// Models/AccessLevel.cs
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class AccessLevel
    {
        [Key] public int AccessLevelID { get; set; }
        [Required, StringLength(20)] public string LevelName { get; set; } = string.Empty;

        public ICollection<AdminOffice>? Admins { get; set; }
    }
}
