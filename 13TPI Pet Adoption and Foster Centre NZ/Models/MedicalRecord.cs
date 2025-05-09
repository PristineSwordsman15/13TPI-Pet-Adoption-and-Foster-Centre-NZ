﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class MedicalRecord
    {
        // ID of individual medical record of pet 
        [Required]
        [Key]
        public int MedicalRecordID { get; set; }

        // Foe
        [Required]
        [ForeignKey("PetID")]
        public int PetID { get; set; }
        [Required]
        [StringLength(25)]
        public string VetName { get; set; }
        [Required]
        [StringLength(100)]
        public string ClinicName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly VisitDate { get; set; }
        [Required]
        public string Diagnosis { get; set; }
        
        public string Treatment { get; set; }
        [Required]
        [StringLength(25)]
        public string VaccinationStatus { get; set; }
        [Required]
        public int MicrochipID { get; set; }
        public string SpecialNeeds { get; set; }
    }
}
