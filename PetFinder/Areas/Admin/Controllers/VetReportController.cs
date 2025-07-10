using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetFinder.Data;
using PetFinder.Models;

namespace PetFinder.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class VetReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VetReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/VetReport
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VetReports.Include(v => v.Dog);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/VetReport/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VetReports == null)
            {
                return NotFound();
            }

            var vetReport = await _context.VetReports
                .Include(v => v.Dog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vetReport == null)
            {
                return NotFound();
            }

            return View(vetReport);
        }

        // GET: Admin/VetReport/Create
        public IActionResult Create()
        {
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "ChipNumber");
            return View();
        }

        // POST: Admin/VetReport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Date,ReporterName,DogId")] VetReport vetReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vetReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "ChipNumber", vetReport.DogId);
            return View(vetReport);
        }

        // GET: Admin/VetReport/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VetReports == null)
            {
                return NotFound();
            }

            var vetReport = await _context.VetReports.FindAsync(id);
            if (vetReport == null)
            {
                return NotFound();
            }
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "ChipNumber", vetReport.DogId);
            return View(vetReport);
        }

        // POST: Admin/VetReport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Date,ReporterName,DogId")] VetReport vetReport)
        {
            if (id != vetReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vetReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VetReportExists(vetReport.Id))
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
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "ChipNumber", vetReport.DogId);
            return View(vetReport);
        }

        // GET: Admin/VetReport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VetReports == null)
            {
                return NotFound();
            }

            var vetReport = await _context.VetReports
                .Include(v => v.Dog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vetReport == null)
            {
                return NotFound();
            }

            return View(vetReport);
        }

        // POST: Admin/VetReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VetReports == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VetReports'  is null.");
            }
            var vetReport = await _context.VetReports.FindAsync(id);
            if (vetReport != null)
            {
                _context.VetReports.Remove(vetReport);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VetReportExists(int id)
        {
          return (_context.VetReports?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
