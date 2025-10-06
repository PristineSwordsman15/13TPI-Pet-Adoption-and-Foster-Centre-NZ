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

    public class MedicalRecord
{
    [Key]
    public int MedicalRecordID { get; set; }

    [Required, DataType(DataType.Date)]
    public DateTime Date { get; set; }

    [Required, StringLength(500)]
    public string Notes { get; set; } = string.Empty;

    [Required]
    public int PetID { get; set; }
    public Pet Pet { get; set; }

    [Required]
    public int VaccinationStatusID { get; set; }
    public VaccinationStatus VaccinationStatus { get; set; }
}
