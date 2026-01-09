using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstApproch_EntityFramework.Models;

namespace DatabaseFirstApproch_EntityFramework.Controllers
{
    public class HomeController : Controller
    {
        private readonly Asp_DOT_NetCore_DBContext _context;

        public HomeController(Asp_DOT_NetCore_DBContext context)
        {
            _context = context;
        }

        // GET: TblStudentUsingEntities
        public async Task<IActionResult> Index()
        {
              return _context.TblStudentUsingEntities != null ? 
                          View(await _context.TblStudentUsingEntities.ToListAsync()) :
                          Problem("Entity set 'Asp_DOT_NetCore_DBContext.TblStudentUsingEntities'  is null.");
        }

        // GET: TblStudentUsingEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblStudentUsingEntities == null)
            {
                return NotFound();
            }

            var tblStudentUsingEntity = await _context.TblStudentUsingEntities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblStudentUsingEntity == null)
            {
                return NotFound();
            }

            return View(tblStudentUsingEntity);
        }

        // GET: TblStudentUsingEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblStudentUsingEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudName,StudGender,StudAge,StudStandard")] TblStudentUsingEntity tblStudentUsingEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblStudentUsingEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblStudentUsingEntity);
        }

        // GET: TblStudentUsingEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblStudentUsingEntities == null)
            {
                return NotFound();
            }

            var tblStudentUsingEntity = await _context.TblStudentUsingEntities.FindAsync(id);
            if (tblStudentUsingEntity == null)
            {
                return NotFound();
            }
            return View(tblStudentUsingEntity);
        }

        // POST: TblStudentUsingEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudName,StudGender,StudAge,StudStandard")] TblStudentUsingEntity tblStudentUsingEntity)
        {
            if (id != tblStudentUsingEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblStudentUsingEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblStudentUsingEntityExists(tblStudentUsingEntity.Id))
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
            return View(tblStudentUsingEntity);
        }

        // GET: TblStudentUsingEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblStudentUsingEntities == null)
            {
                return NotFound();
            }

            var tblStudentUsingEntity = await _context.TblStudentUsingEntities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblStudentUsingEntity == null)
            {
                return NotFound();
            }

            return View(tblStudentUsingEntity);
        }

        // POST: TblStudentUsingEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblStudentUsingEntities == null)
            {
                return Problem("Entity set 'Asp_DOT_NetCore_DBContext.TblStudentUsingEntities'  is null.");
            }
            var tblStudentUsingEntity = await _context.TblStudentUsingEntities.FindAsync(id);
            if (tblStudentUsingEntity != null)
            {
                _context.TblStudentUsingEntities.Remove(tblStudentUsingEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblStudentUsingEntityExists(int id)
        {
          return (_context.TblStudentUsingEntities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
