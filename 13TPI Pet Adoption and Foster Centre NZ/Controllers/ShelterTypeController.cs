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

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers
{
    [Authorize]
    public class ShelterTypeController : Controller
    {
        private readonly Context _context;

        public ShelterTypeController(Context context)
        {
            _context = context;
        }

        // GET: ShelterTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShelterType.ToListAsync());
        }

        // GET: ShelterTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelterType = await _context.ShelterType
                .FirstOrDefaultAsync(m => m.ShelterTypeID == id);
            if (shelterType == null)
            {
                return NotFound();
            }

            return View(shelterType);
        }

        // GET: ShelterTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShelterTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShelterTypeID,Name")] ShelterType shelterType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shelterType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shelterType);
        }

        // GET: ShelterTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelterType = await _context.ShelterType.FindAsync(id);
            if (shelterType == null)
            {
                return NotFound();
            }
            return View(shelterType);
        }

        // POST: ShelterTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShelterTypeID,Name")] ShelterType shelterType)
        {
            if (id != shelterType.ShelterTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shelterType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShelterTypeExists(shelterType.ShelterTypeID))
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
            return View(shelterType);
        }

        // GET: ShelterTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelterType = await _context.ShelterType
                .FirstOrDefaultAsync(m => m.ShelterTypeID == id);
            if (shelterType == null)
            {
                return NotFound();
            }

            return View(shelterType);
        }

        // POST: ShelterTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shelterType = await _context.ShelterType.FindAsync(id);
            if (shelterType != null)
            {
                _context.ShelterType.Remove(shelterType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShelterTypeExists(int id)
        {
            return _context.ShelterType.Any(e => e.ShelterTypeID == id);
        }
    }
}
