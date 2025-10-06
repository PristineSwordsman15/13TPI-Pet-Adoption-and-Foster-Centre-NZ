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

public class Coordinator
{
    [Key]
    public int CoordinatorID { get; set; }

    [Required, StringLength(25)]
    public string FirstName { get; set; } = string.Empty;

    [Required, StringLength(25)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public int FranchiseID { get; set; }
    public Franchise Franchise { get; set; }

    [Required]
    public int PetGroupID { get; set; }
    public PetGroup PetGroup { get; set; }

    [Required, EmailAddress]
    public string EmailAddress { get; set; } = string.Empty;

    [Required]
    [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Contact number must be 10–15 digits.")]
    public string ContactNo { get; set; } = string.Empty;

    [NotMapped]
    public IFormFile? ImageFile { get; set; }

    public string? ImageName { get; set; }
}
