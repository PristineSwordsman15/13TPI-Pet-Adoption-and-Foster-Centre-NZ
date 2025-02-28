namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Shelter
    {
        public int ShelterID { get; set; }
        public string ShelterName { get; set; }
        public int FranchiseID { get; set; }
        public int LocationID { get; set; }
        public int  AvailableBeds { get; set; }
        public int OccupiedBeds { get; set; }
        public string ContactNo { get; set; }
        public string OperatingHours { get; set; }
        public string ShelterType { get; set; }
        public string EmailAddress { get; set; }

    }
}
