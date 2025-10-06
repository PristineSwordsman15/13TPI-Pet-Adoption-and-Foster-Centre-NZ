
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data.Helpers;


namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required, Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public int PaymentTypeID { get; set; }
        public PaymentType PaymentType { get; set; }

        [Required]
        public int PaymentMethodID { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        public int PaymentStatusID { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        [Required]
        public string UserID { get; set; } = string.Empty;

        [Required, DataType(DataType.Date)]
        public DateTime PaymentDate { get; internal set; }
    }
}