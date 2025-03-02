using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Payment
    {
        [Required]
        [Key]
        public int PaymentID { get; set; }
        [Required]

        public int UserID { get; set; }
        [Required]
        [StringLength(25)]
        public string PaymentType { get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }
        [Required]
        [StringLength(20)]
        [RegularExpression(@"^\d{11}$, ErrorMessage = Only NZD is accepted")]
        public decimal Currency { get; set; }
        

        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public int TransactionID { get; set; }
        public string PaymentStatus { get; set; }
        public string Notes { get; set; }
    }
}
