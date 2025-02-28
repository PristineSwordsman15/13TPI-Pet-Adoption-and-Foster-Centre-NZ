namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class MedicalRecord
    {
        public int MedicalID { get; set; }
        public int PetID { get; set; }
        public string VetName { get; set; }
        public string ClinicName { get; set; }
        public DateOnly VisitDate { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public string VaccinationStatus { get; set; }
        public int MicrochipID { get; set; }
        public string SpecialNeeds { get; set; }
    }
}
