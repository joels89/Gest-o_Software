using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestao_Software.Models;
using Gestao_Software.Data;

namespace Gestao_Software.Controllers
{
    public class SoftwareRequirementsController : Controller
    {
        private readonly ProjectContext _context;

        public SoftwareRequirementsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: SoftwareRequirements
        public async Task<IActionResult> Index(int id)
        {
            var softwareRequirementContext = _context.SoftwareRequirement.Include(s => s.Project);
            return View(await softwareRequirementContext.ToListAsync());
        }

        // GET: SoftwareRequirements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softwareRequirement = await _context.SoftwareRequirement
                .Include(s => s.Project)
                .FirstOrDefaultAsync(m => m.SoftwareRequirementId == id);
            if (softwareRequirement == null)
            {
                return NotFound();
            }

            return View(softwareRequirement);
        }

        // GET: SoftwareRequirements/Create
        public IActionResult Create()
        {
            ViewData["ListOfProjects"] = new SelectList(_context.Project);

            return View();
        }

        // POST: SoftwareRequirements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoftwareRequirementId,Name,Description,ProjectId")] SoftwareRequirement softwareRequirement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(softwareRequirement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Set<Project>(), "ProjectId", "Name", softwareRequirement.Project.ProjectId);
            return View(softwareRequirement);
        }

        // GET: SoftwareRequirements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softwareRequirement = await _context.SoftwareRequirement.FindAsync(id);
            if (softwareRequirement == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Set<Project>(), "ProjectId", "Name", softwareRequirement.Project.ProjectId);
            return View(softwareRequirement);
        }

        // POST: SoftwareRequirements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SoftwareRequirementId,Name,Description,ProjectId")] SoftwareRequirement softwareRequirement)
        {
            if (id != softwareRequirement.SoftwareRequirementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(softwareRequirement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoftwareRequirementExists(softwareRequirement.SoftwareRequirementId))
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
            ViewData["ProjectId"] = new SelectList(_context.Set<Project>(), "ProjectId", "Name", softwareRequirement.Project.ProjectId);
            return View(softwareRequirement);
        }

        // GET: SoftwareRequirements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softwareRequirement = await _context.SoftwareRequirement
                .Include(s => s.Project)
                .FirstOrDefaultAsync(m => m.SoftwareRequirementId == id);
            if (softwareRequirement == null)
            {
                return NotFound();
            }

            return View(softwareRequirement);
        }

        // POST: SoftwareRequirements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var softwareRequirement = await _context.SoftwareRequirement.FindAsync(id);
            _context.SoftwareRequirement.Remove(softwareRequirement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoftwareRequirementExists(int id)
        {
            return _context.SoftwareRequirement.Any(e => e.SoftwareRequirementId == id);
        }
    }
}
