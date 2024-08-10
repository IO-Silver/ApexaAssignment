using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApexaAssignment.Data;
using ApexaAssignment.Models;

namespace ApexaAssignment.Controllers
{
    public class AdvisorsController : Controller
    {
        private readonly ApexaAssignmentContext _context;

        public AdvisorsController(ApexaAssignmentContext context)
        {
            _context = context;
        }

        // GET: Advisors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Advisor.ToListAsync());
        }

        // GET: Advisors/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advisor = await _context.Advisor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advisor == null)
            {
                return NotFound();
            }

            return View(advisor);
        }

        // GET: Advisors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Advisors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Adress,Phone,HealthStatus")] Advisor advisor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(advisor);
        }

        // GET: Advisors/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advisor = await _context.Advisor.FindAsync(id);
            if (advisor == null)
            {
                return NotFound();
            }
            return View(advisor);
        }

        // POST: Advisors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Adress,Phone,HealthStatus")] Advisor advisor)
        {
            if (id != advisor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advisor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvisorExists(advisor.Id))
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
            return View(advisor);
        }

        // GET: Advisors/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advisor = await _context.Advisor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advisor == null)
            {
                return NotFound();
            }

            return View(advisor);
        }

        // POST: Advisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var advisor = await _context.Advisor.FindAsync(id);
            if (advisor != null)
            {
                _context.Advisor.Remove(advisor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvisorExists(long id)
        {
            return _context.Advisor.Any(e => e.Id == id);
        }
    }
}
