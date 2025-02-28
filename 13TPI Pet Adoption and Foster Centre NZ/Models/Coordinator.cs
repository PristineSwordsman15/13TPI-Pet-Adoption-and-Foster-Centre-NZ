namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Coordinator
    {
        public int CoordinatorID { get; set; }
        public int FranchiseID { get; set; }
        public int PetGroupID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int ContactNo { get; set; }
        public DateTime HireDate { get; set; }
        public string ExperienceLevel { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}
