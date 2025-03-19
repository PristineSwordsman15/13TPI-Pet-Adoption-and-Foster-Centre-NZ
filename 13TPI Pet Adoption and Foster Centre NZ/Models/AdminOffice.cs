﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models
{
    public class AdminOffice
    {
        // Primary key for AdminOffice entity 
        [Required]// Ensures the field is mandatory
        [Key]// Makes the below property a primary key
        public int AdminID { get; set; }

        // Foreign Key linking to the User entity
        [Required]// Ensures this field is mandatory
        [ForeignKey("UserID")]// Specifies the foreign key relationship
        public int UserID { get; set; }

        // First Name of the admin
        [Required]// Field is required
        [StringLength(25,MinimumLength = 2)]// Limits the length between 2 and 25 characters
        public string FirstName { get; set; }

        //Last Name of the admin
        [Required]//Field is required
        [StringLength(25, MinimumLength =2)]// Limits the length between 2 and 25 characters
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [RegularExpression(@"^\d{11}$",ErrorMessage ="Contact number must be 11 digits")]
        public string ContactNo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateHired { get; set; }
        [Required]
        [StringLength (20)]
        public string AccessLevel { get; set; }
      
    }
}
