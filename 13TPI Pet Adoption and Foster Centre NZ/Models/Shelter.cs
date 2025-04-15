using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Shelter
    {
        // ID of shelter 
        [Required]
        [Key]
        public int ShelterID { get; set; }
        // Name of shelter
        [Required]
        [StringLength(50)]
        public string ShelterName { get; set; }
        // Links which franchise is running the shelter
        [Required]
        [ForeignKey("FranchiseID")]
        public int FranchiseID { get; set; }

        // ID of location of franchise/shelter
        [Required]
        [ForeignKey("LocationID")]
        public int LocationID { get; set; }

        // The amount of beds a shelter has 
        [Required]
        public int  AvailableBeds { get; set; }

        // Amount of beds taken in a shelter 
        [Required]
        public int OccupiedBeds { get; set; }

        // Contact no. of shelter  
        [Required]
        [RegularExpression(@"^\d{11}",ErrorMessage = "Contact No must be 11 digits")]
        public string ContactNo { get; set; }

        // Operating houra of shelter 
        public string OperatingHours { get; set; }

        // Type of pet shelter (Government vs private) 
        [Required, StringLength(50)]
        public string ShelterType { get; set; }

        //  Email address of Shelter
        [EmailAddress]
        public string EmailAddress { get; set; }

        // Title of image 
        [Column(TypeName = "nvarchar(50)")]
        public string? Title { get; set; }

        // File name for image 
        [Column(TypeName = "nvarchar(100)")]
        [NotMapped]
        [DisplayName("Image Name")]
        public string? ImageName { get; set; }

        // Uploadable image file (not mapped) 
        [NotMapped]
        [DisplayName("Upload Files")]
        public IFormFile? ImageFile { get; set; }

    }
}