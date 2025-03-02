using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Franchise
    {
        public int FranchiseID { get; set; }
        public string FranchiseName { get; set; }
        public string ContactNo { get; set; }
        public int LocationID { get; set; }
        public string EmailAddress { get; set; }
        public string OperatingHours { get; set; }
        public int OwnerID { get; set; }

    }
}
