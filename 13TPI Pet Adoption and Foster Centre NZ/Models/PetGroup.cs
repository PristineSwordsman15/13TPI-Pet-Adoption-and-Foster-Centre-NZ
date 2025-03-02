using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class PetGroup
    {
        public int PetGroupID { get; set; }
        public int PetID { get; set;}
        public string PetGroupName { get; set; }
        public string PeGroupDescriptiom { get; set; }
    }
}
