using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodID { get; set; }

        [Required, StringLength(25)]
        public string MethodName { get; set; } = string.Empty;

        public ICollection<Payment>? Payments { get; set; }
    }
}
