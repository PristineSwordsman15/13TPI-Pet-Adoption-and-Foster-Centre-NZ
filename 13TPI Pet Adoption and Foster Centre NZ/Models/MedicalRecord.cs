using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class MedicalRecord
    {
        // ID of individual medical record of pet 
        [Key]
        public int MedicalRecordID { get; set; }

        // Fk ->  Pet
        
        public int PetID { get; set; }
        public virtual Pet? Pet { get; set; }

        [Required]
        [StringLength(25)]
        public string VetName { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string ClinicName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; }
        [Required]
        public string Diagnosis { get; set; }  = string.Empty;

        public string Treatment { get; set; }
       public string VaccinationStatus { get; set; }
        public virtual VaccinationStatus? StatusName { get; set; }

        [Required]
        public int MicrochipID { get; set; }
        public string SpecialNeeds { get; set; }
    }
}
