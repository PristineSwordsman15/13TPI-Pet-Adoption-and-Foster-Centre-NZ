
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


    public class Shelter
{
    [Key]
    public int ShelterID { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int FranchiseID { get; set; }
    public Franchise Franchise { get; set; }

    [Required]
    public int LocationID { get; set; }
    public Location Location { get; set; }

    [Required]
    public int ShelterTypeID { get; set; }
    public ShelterType ShelterType { get; set; }
}