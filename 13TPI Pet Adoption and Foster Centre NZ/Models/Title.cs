// Models/Title.cs
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Title
    {
        public int TitleID { get; set; }
        [Required] public string TitleName { get; set; }
    }
}