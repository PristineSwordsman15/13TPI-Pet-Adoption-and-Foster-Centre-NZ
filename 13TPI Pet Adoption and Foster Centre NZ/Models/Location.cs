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

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
public class Location
{
    [Key]
    public int LocationID { get; set; }

    [Required, StringLength(150)]
    public string Address { get; set; } = string.Empty;

    [Required, StringLength(25)]
    public string Surburb { get; set; } = string.Empty;

    [Required, StringLength(50)]
    public string City { get; set; } = string.Empty;

    [Required, StringLength(50)]
    public string Region { get; set; } = string.Empty;

    [Required, RegularExpression(@"^\d{4}$", ErrorMessage = "Postcode must be 4 digits.")]
    public string PostCode { get; set; } = string.Empty;

    [Required, StringLength(50)]
    public string Country { get; set; } = string.Empty;

    public ICollection<Franchise> Franchises { get; set; }
    public ICollection<Shelter> Shelters { get; set; }
}
