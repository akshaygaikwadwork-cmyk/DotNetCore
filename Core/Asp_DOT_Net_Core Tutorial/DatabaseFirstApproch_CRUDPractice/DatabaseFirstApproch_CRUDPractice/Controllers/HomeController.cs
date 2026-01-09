using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstApproch_CRUDPractice.Model;

namespace DatabaseFirstApproch_CRUDPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly Asp_DOT_NetCore_DBContext _context;

        public HomeController(Asp_DOT_NetCore_DBContext context)
        {
            _context = context;
        }

        // GET: TblEmployees
        public async Task<IActionResult> Index()
        {
              return _context.TblEmployees != null ? 
                          View(await _context.TblEmployees.ToListAsync()) :
                          Problem("Entity set 'Asp_DOT_NetCore_DBContext.TblEmployees'  is null.");
        }

        // GET: TblEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblEmployees == null)
            {
                return NotFound();
            }

            var tblEmployee = await _context.TblEmployees
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (tblEmployee == null)
            {
                return NotFound();
            }

            return View(tblEmployee);
        }

        // GET: TblEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpId,EmpName,EmpGender,EmpSalary,EmpAge")] TblEmployee tblEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblEmployee);
        }

        // GET: TblEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblEmployees == null)
            {
                return NotFound();
            }

            var tblEmployee = await _context.TblEmployees.FindAsync(id);
            if (tblEmployee == null)
            {
                return NotFound();
            }
            return View(tblEmployee);
        }

        // POST: TblEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpId,EmpName,EmpGender,EmpSalary,EmpAge")] TblEmployee tblEmployee)
        {
            if (id != tblEmployee.EmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblEmployeeExists(tblEmployee.EmpId))
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
            return View(tblEmployee);
        }

        // GET: TblEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblEmployees == null)
            {
                return NotFound();
            }

            var tblEmployee = await _context.TblEmployees
                .FirstOrDefaultAsync(m => m.EmpId == id);
            if (tblEmployee == null)
            {
                return NotFound();
            }

            return View(tblEmployee);
        }

        // POST: TblEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblEmployees == null)
            {
                return Problem("Entity set 'Asp_DOT_NetCore_DBContext.TblEmployees'  is null.");
            }
            var tblEmployee = await _context.TblEmployees.FindAsync(id);
            if (tblEmployee != null)
            {
                _context.TblEmployees.Remove(tblEmployee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblEmployeeExists(int id)
        {
          return (_context.TblEmployees?.Any(e => e.EmpId == id)).GetValueOrDefault();
        }
    }
}
