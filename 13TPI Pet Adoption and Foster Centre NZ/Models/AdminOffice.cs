namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class AdminOffice
    {
        public int AdminID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }
        public DateTime DateHired { get; set; }
        public string AccessLevel { get; set; }
        public int RoleID { get; set; }
    }
}
