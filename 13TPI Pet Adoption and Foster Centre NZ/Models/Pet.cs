using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pet
{
    public int PetID { get; set; }
    [Required] public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }

    // FKs
    public int PetGroupID { get; set; }
    public PetGroup PetGroup { get; set; }

    public int PetStatusID { get; set; }
    public PetStatus PetStatus { get; set; }
    [NotMapped]
    public IFormFile? ImageFile { get; set; }

    public string? ImageName { get; set; }

    public ICollection<MedicalRecord> MedicalRecords { get; set; }
}