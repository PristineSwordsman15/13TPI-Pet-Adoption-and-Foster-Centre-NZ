
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

    public class Pet
{
    [Key]
    public int PetID { get; set; }

    [Required, StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [Required]
    public int PetGroupID { get; set; }
    public PetGroup PetGroup { get; set; }

    [Required]
    public int PetStatusID { get; set; }
    public PetStatus PetStatus { get; set; }

    [NotMapped]
    public IFormFile? ImageFile { get; set; }

    public string? ImageName { get; set; }

    public ICollection<MedicalRecord> MedicalRecords { get; set; }
}