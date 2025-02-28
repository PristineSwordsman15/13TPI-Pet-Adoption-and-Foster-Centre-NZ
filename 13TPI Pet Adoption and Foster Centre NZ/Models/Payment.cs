
namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int UserID { get; set; }
        public string PaymentType { get; set; }
        public decimal Amount { get; set; }
        public decimal Currency { get; set; }
        public DateTime PaymentDate { get;set;}
        public string PaymentMethod { get; set; }
        public int TransactionID { get; set; }

