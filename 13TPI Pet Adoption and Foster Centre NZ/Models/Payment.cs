using System;
using System.ComponentModel.DataAnnotations;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        // FK → User
        public int UserID { get; set; }
        public virtual User? User { get; set; } // Link to Identity 

        // Normalized → PaymentType Lookup
        public int PaymentTypeID { get; set; }
        public virtual PaymentType? PaymentType { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        // Currency fixed to NZD → no need for Regex
        public string Currency { get; set; } = "NZD";

        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        public int PaymentMethodID { get; set; }
        public virtual PaymentMethod? PaymentMethod { get; set; }

        public int TransactionID { get; set; }

        public int PaymentStatusID { get; set; }
        public virtual PaymentStatus? PaymentStatus { get; set; }

        public string? Notes { get; set; }
    }
}
