using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestao_Software.Data;
using Gestao_Software.Models;
using Gestao_Software.ViewModels;

namespace Gestao_Software.Controllers
{
    public class CollaboratorsController : Controller
    {
        private readonly ProjectContext _context;

        public CollaboratorsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Collaborators
        public async Task<IActionResult> Index(int id)
        {
            var collaboratorContext = _context.Collaborator.Where(c => c.ProjectId == id);
            return View(await collaboratorContext.ToListAsync());
        }

        public async Task<IActionResult> List(string name, int page = 1)
        {
            var projectSearch = _context.Collaborator
            .Where(b => name == null || b.Nome.Contains(name));

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                TotalItems = projectSearch.Count()
            };

            if (pagingInfo.CurrentPage > pagingInfo.TotalPages)
            {
                pagingInfo.CurrentPage = pagingInfo.TotalPages;
            }

            if (pagingInfo.CurrentPage < 1)
            {
                pagingInfo.CurrentPage = 1;
            }
            var collaborator = await projectSearch
                .Include(b => b.Project)
                .OrderBy(b => b.Nome)   
                .ToListAsync();

            return View(
                new CollaboratorListViewModel
                {
                    Collaborators = collaborator,
                    PagingInfo = pagingInfo,
                    NameSearched = name

                }
            );
        }

        // GET: Collaborators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaborator = await _context.Collaborator
                .Include(c => c.Project)
                .FirstOrDefaultAsync(m => m.CollaboratorId == id);
            if (collaborator == null)
            {
                return NotFound();
            }

            return View(collaborator);
        }

        // GET: Collaborators/Create
        public async Task<IActionResult> CreateAsync(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var collaborator = await _context.Collaborator.FindAsync(id);
            if (collaborator == null)
            {
                return NotFound();
            }

            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "Name", collaborator.ProjectId);
            return View(collaborator);
        }

        // POST: Collaborators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CollaboratorId,Nome,Funcao,Photo,ProjectId")] Collaborator collaborator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collaborator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "Name", collaborator.ProjectId);
            return View(collaborator);
        }

        // GET: Collaborators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaborator = await _context.Collaborator.FindAsync(id);
            if (collaborator == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "Name", collaborator.ProjectId);
            return View(collaborator);
        }

        // POST: Collaborators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CollaboratorId,Nome,Funcao,Photo,ProjectId")] Collaborator collaborator)
        {
            if (id != collaborator.CollaboratorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collaborator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollaboratorExists(collaborator.CollaboratorId))
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
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "Name", collaborator.ProjectId);
            return View(collaborator);
        }

        // GET: Collaborators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaborator = await _context.Collaborator
                .Include(c => c.Project)
                .FirstOrDefaultAsync(m => m.CollaboratorId == id);
            if (collaborator == null)
            {
                return NotFound();
            }

            return View(collaborator);
        }

        // POST: Collaborators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collaborator = await _context.Collaborator.FindAsync(id);
            _context.Collaborator.Remove(collaborator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollaboratorExists(int id)
        {
            return _context.Collaborator.Any(e => e.CollaboratorId == id);
        }
    }
}
