using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class MedicalRecord
    {
        public int MedicalRecordID { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        // FKs
        public int PetID { get; set; }
        public Pet Pet { get; set; }

        public int VaccinationStatusID { get; set; }
        public VaccinationStatus VaccinationStatus { get; set; }
    }
}