using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class PaymentStatus
    {
        public int PaymentStatusID { get; set; }
        [Required] public string StatusName { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}

