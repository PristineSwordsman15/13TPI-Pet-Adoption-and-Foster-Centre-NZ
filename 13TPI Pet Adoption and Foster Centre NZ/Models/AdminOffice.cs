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
using System.ComponentModel;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;

public class AdminOffice
{
    [Key]
    public int AdminID { get; set; }

    [Required]
    public int UserID { get; set; }

    [Required, StringLength(25, MinimumLength = 2)]
    public string FirstName { get; set; } = string.Empty;

    [Required, StringLength(25, MinimumLength = 2)]
    public string LastName { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string EmailAddress { get; set; } = string.Empty;

    [Required]
    [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Contact number must be 10–15 digits.")]
    public string ContactNo { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime DateHired { get; set; }

    [Required]
    public int AccessLevelID { get; set; }
    public virtual AccessLevel? AccessLevel { get; set; }

    [Required, StringLength(20)]
    public string LevelName { get; set; } = string.Empty;

    [Required, StringLength(50)]
    public string TitleName { get; set; } = string.Empty;

    [Required]
    public int TitleID { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string? ImageName { get; set; }

    [NotMapped]
    [DisplayName("Upload Files")]
    public IFormFile? ImageFile { get; set; }
}

