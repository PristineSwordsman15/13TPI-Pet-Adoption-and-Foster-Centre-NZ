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
using System.IO;
using Microsoft.AspNetCore.Identity;

namespace _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Controllers
{
    [Authorize]
    public class AdminOfficeController : Controller
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdminOfficeController(Context context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment; 
        }

        // GET: AdminOffices
        public async Task<IActionResult> Index(string AdminID)

        {
            if (_context.AdminOffice == null)
            {
                return Problem("Entity set '13TPIPetAdoption/FosterCentreNZContext.AdminOffice'  is null.");
            }

            var adminOffices = from a in _context.AdminOffice
                         select a;

            if (!String.IsNullOrEmpty(AdminID))
            {
                adminOffices = adminOffices.Where(s => s.AccessLevel!.ToUpper().Contains(AdminID.ToUpper()));
            }

            return View(await adminOffices.ToListAsync());
        }

        // GET: AdminOffices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminOffice = await _context.AdminOffice
                .FirstOrDefaultAsync(m => m.AdminID == id);
            if (adminOffice == null)
            {
                return NotFound();
            }

            return View(adminOffice);
        }

        // GET: AdminOffices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminOffices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminID,UserID,FirstName,LastName,EmailAddress,ContactNo,DateHired,AccessLevel,Title,ImageName,ImageFile")] AdminOffice adminOffice)
        {
            if (!ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(adminOffice.ImageFile.FileName);
                string extension = Path.GetExtension(adminOffice.ImageFile.FileName);
                adminOffice.ImageName = fileName = fileName + DateTime.Now.ToString("yyyymmddhhmmss") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await adminOffice.ImageFile.CopyToAsync(fileStream);
                }
                _context.Add(adminOffice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(adminOffice);
        }

        // GET: AdminOffices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminOffice = await _context.AdminOffice.FindAsync(id);
            if (adminOffice == null)
            {
                return NotFound();
            }
            return View(adminOffice);
        }

        // POST: AdminOffices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdminID,UserID,FirstName,LastName,EmailAddress,ContactNo,DateHired,AccessLevel,Title,ImageName,ImageFile")] AdminOffice adminOffice)
        {
            if (id != adminOffice.AdminID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminOffice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminOfficeExists(adminOffice.AdminID))
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
            return View(adminOffice);
        }

        // GET: AdminOffices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminOffice = await _context.AdminOffice
                .FirstOrDefaultAsync(m => m.AdminID == id);
            if (adminOffice == null)
            {
                return NotFound();
            }

            return View(adminOffice);
        }

        // POST: AdminOffices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminOffice = await _context.AdminOffice.FindAsync(id);
            if (adminOffice != null)
            {
                _context.AdminOffice.Remove(adminOffice);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminOfficeExists(int id)
        {
            return _context.AdminOffice.Any(e => e.AdminID == id);
        }
    }
}
