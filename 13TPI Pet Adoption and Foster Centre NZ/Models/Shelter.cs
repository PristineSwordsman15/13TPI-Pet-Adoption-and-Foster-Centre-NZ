using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Shelter
    {
        public int ShelterID { get; set; }
        public string ShelterName { get; set; }
        public int FranchiseID { get; set; }
        public int LocationID { get; set; }
        public int  AvailableBeds { get; set; }
        public int OccupiedBeds { get; set; }
        public string ContactNo { get; set; }
        public string OperatingHours { get; set; }
        public string ShelterType { get; set; }
        public string EmailAddress { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [NotMapped]
        [DisplayName("Image Name")]
        public string ImageName { get; set; }
        [NotMapped]
        [DisplayName("Upload Files")]
        public IFormFile ImageFile { get; set; }

    }
}
