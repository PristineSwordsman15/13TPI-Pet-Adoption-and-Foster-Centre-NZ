using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data
{
    //Add profile data for application users 
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
