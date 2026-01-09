using CodeFirstApproch_CRUDPractice.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace CodeFirstApproch_CRUDPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmpDbContext _dbContext;

        public HomeController(EmpDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var EmpData = await _dbContext.tbl_Employee.ToListAsync();
                return View(EmpData);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return View("Error", message);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeModel modelObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _dbContext.tbl_Employee.AddAsync(modelObj);
                    await _dbContext.SaveChangesAsync();
                    TempData["InsertMessage"] = "Employee Created Successfully.";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return View("Error", message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                else
                {
                    var EmpData = await _dbContext.tbl_Employee.FindAsync(id);
                    if (EmpData == null)
                    {
                        return NotFound();
                    }
                    return View(EmpData);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return View("Error", message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, EmployeeModel modelObj)
        {
            try
            {
                if (id == null || modelObj == null)
                {
                    return NotFound();
                }
                else
                {
                    _dbContext.tbl_Employee.Update(modelObj);
                    await _dbContext.SaveChangesAsync();
                    TempData["UpdateMessage"] = "Employee Updated Successfully.";
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return View("Error", message);
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                else
                {
                    var EmpData = await _dbContext.tbl_Employee.FirstOrDefaultAsync(x => x.EmpId == id);
                    if (EmpData == null)
                    {
                        return NotFound();
                    }
                    return View(EmpData);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return View("Error", message);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                else
                {
                    var EmpData = await _dbContext.tbl_Employee.FirstOrDefaultAsync(x => x.EmpId == id);
                    if (EmpData == null)
                    {
                        return NotFound();
                    }
                    return View(EmpData);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return View("Error", message);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                else
                {
                    var EmpData = await _dbContext.tbl_Employee.FindAsync(id);
                    if (EmpData == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        _dbContext.tbl_Employee.Remove(EmpData);
                        await _dbContext.SaveChangesAsync();
                        TempData["Delete_Success"] = "Student Data Deleted Successfully!!!";
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return View("Error", message);
            }
        }
    }
}
