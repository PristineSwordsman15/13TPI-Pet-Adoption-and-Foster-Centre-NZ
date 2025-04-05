using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Shelter
    {
        // ID of shelter 
        public int ShelterID { get; set; }
        // ID of franchise handling shelter
        public string ShelterName { get; set; }
        public int FranchiseID { get; set; }

        // ID of location of franchise/shelter
        public int LocationID { get; set; }

        // The amount of beds a shelter has 
        public int  AvailableBeds { get; set; }

        // Amount of beds taken in a shelter 
        public int OccupiedBeds { get; set; }

        // Contact no. of shelter  
        public string ContactNo { get; set; }

        // Operating houra of shelter 
        public string OperatingHours { get; set; }

        // Type of pet shelter (Government vs private) 
        public string ShelterType { get; set; }

        // Shelter email address
        public string EmailAddress { get; set; }

        // Title of image 
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        // File name for image 
        [Column(TypeName = "nvarchar(100)")]
        [NotMapped]
        [DisplayName("Image Name")]
        public string ImageName { get; set; }

        // Uploadable image file (not mapped) 
        [NotMapped]
        [DisplayName("Upload Files")]
        public IFormFile ImageFile { get; set; }

    }
}
