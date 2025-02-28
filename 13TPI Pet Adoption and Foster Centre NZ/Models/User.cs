namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ContactNo { get; set; }
        public int LocationID { get; set; }
        public int RoleID { get; set; }
        public int FranchiseID { get; set; }
        public string ProfileImageUrl { get; set; }

    }
}
