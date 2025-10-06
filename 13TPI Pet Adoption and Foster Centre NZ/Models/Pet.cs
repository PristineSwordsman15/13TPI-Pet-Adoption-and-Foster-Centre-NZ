using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{

    public class Pet
    {
        public int PetID { get; set; }



        public int PetGroupID { get; set; }
        public virtual PetGroup PetGroup { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int PetStatusID { get; set; }

        public string StatusName { get; set; }
        public virtual PetStatus PetStatus { get; set; }

        public int VaccinationStatusID { get; set; }
        public virtual VaccinationStatus VaccinationStatus { get; set; }

      public string MedicalRecord { get; set; }
        public virtual MedicalRecord MedicalRecords { get; set; }

        public int ShelterID { get; set; }
        public virtual Shelter Shelter { get; set; }
    }
}