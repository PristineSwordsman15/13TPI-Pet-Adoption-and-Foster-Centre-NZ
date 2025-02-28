namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Pet
    {
        public int PetID { get; set; }
        public string PetName { get; set; }
        public int  PetGroupID { get; set;}
        public string Species { get; set; }
        public string Breed { get; set; }
        public int PetAge { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string PetStatus { get; set; }
        public string ImageUrl { get; set; }

    }
}
