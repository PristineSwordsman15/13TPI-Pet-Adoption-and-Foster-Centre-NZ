using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using System.ComponentModel.DataAnnotations;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        // FKs
        public int PaymentTypeID { get; set; }
        public PaymentType PaymentType { get; set; }

        public int PaymentMethodID { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public int PaymentStatusID { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        // Link to Identity User
        [Required] public string UserID { get; set; }
        public DateTime PaymentDate { get; internal set; }
    }
}

