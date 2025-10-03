using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers
{
    public class AdminOfficesController : Controller
    {
        private readonly Context _context;
        private const int PageSize = 5; // paging size

        public AdminOfficesController(Context context)
        {
            _context = context;
        }

        // Index with search, sort, and paging
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;

            // Sort order toggles
            ViewData["FirstNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "fname_desc" : "";
            ViewData["LastNameSortParm"] = sortOrder == "lname" ? "lname_desc" : "lname";
            ViewData["EmailSortParm"] = sortOrder == "email" ? "email_desc" : "email";
            ViewData["DateSortParm"] = sortOrder == "date" ? "date_desc" : "date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var admins = from a in _context.AdminOffice
                         select a;

            // Search
            if (!String.IsNullOrEmpty(searchString))
            {
                admins = admins.Where(a =>
                    a.FirstName.Contains(searchString) ||
                    a.LastName.Contains(searchString) ||
                    a.EmailAddress.Contains(searchString) ||
                    a.ContactNo.Contains(searchString));
            }

            // Sorting
            admins = sortOrder switch
            {
                "fname_desc" => admins.OrderByDescending(a => a.FirstName),
                "lname" => admins.OrderBy(a => a.LastName),
                "lname_desc" => admins.OrderByDescending(a => a.LastName),
                "email" => admins.OrderBy(a => a.EmailAddress),
                "email_desc" => admins.OrderByDescending(a => a.EmailAddress),
                "date" => admins.OrderBy(a => a.DateHired),
                "date_desc" => admins.OrderByDescending(a => a.DateHired),
                _ => admins.OrderBy(a => a.FirstName),
            };

            int currentPage = pageNumber ?? 1;
            return View(await PaginatedList<AdminOffice>.CreateAsync(admins.AsNoTracking(), currentPage, PageSize));
        }
    }
}
