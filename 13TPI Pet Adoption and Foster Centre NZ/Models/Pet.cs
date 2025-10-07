namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Pet
    {
        public int PetID { get; set; }
        public string PetName { get; set; }
        public int ShelterID { get; set; }

        public int BreedID { get; set; }

        public string Colour { get; set; }

        bool Adoption { get; set; }

    }
}
