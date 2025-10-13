using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Models;
using Microsoft.AspNetCore.Authorization;
using X.PagedList.Extensions;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers
{
    [Authorize]
    public class BreedsController : Controller
    {
        private readonly Context _context;

        public BreedsController(Context context)
        {
            _context = context;
        }

        // GET: Breeds
        public async Task<ViewResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewData["ProductSortParm"] = sortOrder == "Product" ? "product_desc" : "Product";
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var breeds = _context.Breed.Include(p => p.BreedName).AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                breeds = breeds.Where(p => p.BreedName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "product_desc":
                    breeds = breeds.OrderByDescending(p => p.BreedName);
                    break;
                case "Product":
                default:
                    breeds = breeds.OrderBy(p => p.BreedName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(breeds.ToPagedList(pageNumber, pageSize));
        }


        // GET: Breeds/Details/5
        public async Task<IActionResult> Details(int? id)

        {

            if (id == null)
            {
                return NotFound();
            }

            var breed = await _context.Breed
                .Include(p => p.BreedName)
                .FirstOrDefaultAsync(m => m.BreedID == id);
            if (breed == null)
            {
                return NotFound();
            }

            return View(breed);
        }

        // GET: Breeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Breeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BreedID,BreedName")] Breed breed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(breed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(breed);
        }

        // GET: Breeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breed = await _context.Breed.FindAsync(id);
            if (breed == null)
            {
                return NotFound();
            }
            return View(breed);
        }

        // POST: Breeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BreedID,BreedName")] Breed breed)
        {
            if (id != breed.BreedID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(breed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreedExists(breed.BreedID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(breed);
        }

        // GET: Breeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breed = await _context.Breed
                .FirstOrDefaultAsync(m => m.BreedID == id);
            if (breed == null)
            {
                return NotFound();
            }

            return View(breed);
        }

        // POST: Breeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var breed = await _context.Breed.FindAsync(id);
            if (breed != null)
            {
                _context.Breed.Remove(breed);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BreedExists(int id)
        {
            return _context.Breed.Any(e => e.BreedID == id);
        }
    }
}
