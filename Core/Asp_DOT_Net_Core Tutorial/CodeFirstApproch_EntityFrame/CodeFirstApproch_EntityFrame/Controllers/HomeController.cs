using CodeFirstApproch_EntityFrame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CodeFirstApproch_EntityFrame.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext dbContext;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(StudentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Data()
        {
            var StudentData = await dbContext.tbl_StudentUsingEntity.ToListAsync();
            return View(StudentData);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> Gender = new()
            {
                new SelectListItem {Value = "M", Text = "Male"},
                new SelectListItem {Value = "F", Text = "Female"}
            };

            ViewBag.Gender = Gender;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // this is prevent data from hacker or who are calling submit from external i.e.csrf
        //Note - if you inspect then chekc at last at submit button there is hiddent tokenbase genrate hidden value it is creating when submit called from this appplication not by outside external/hacker
        public async Task<IActionResult> Create(StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                await dbContext.tbl_StudentUsingEntity.AddAsync(studentModel);
                await dbContext.SaveChangesAsync();
                TempData["Insert_Success"] = "Student Created Successfully!!!";
                return RedirectToAction("Data", "Home");
            }
            return View(studentModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id) // here we set null when id is 0 or null using ?
        {
            if (id == null || dbContext.tbl_StudentUsingEntity == null)
            {
                return NotFound();
            }
            var StudentData = await dbContext.tbl_StudentUsingEntity.FirstOrDefaultAsync(x => x.Id == id);
            if (StudentData == null)
            {
                return NotFound();
            }
            return View(StudentData);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            List<SelectListItem> Gender = new()
            {
                new SelectListItem {Value = "M", Text = "Male"},
                new SelectListItem {Value = "F", Text = "Female"}
            };

            ViewBag.Gender = Gender;

            if (id == null || dbContext.tbl_StudentUsingEntity == null)
            {
                return NotFound();
            }
            var StudentData = await dbContext.tbl_StudentUsingEntity.FindAsync(id);
            if (StudentData == null)
            {
                return NotFound();
            }
            return View(StudentData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // this is prevent data from hacker or who are calling submit from external i.e.csrf
        //Note - if you inspect then chekc at last at submit button there is hiddent tokenbase genrate hidden value it is creating when submit called from this appplication not by outside external/hacker
        public async Task<IActionResult> Edit(int? id,StudentModel studentModel)
        {
            if (id == null || dbContext.tbl_StudentUsingEntity == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                dbContext.tbl_StudentUsingEntity.Update(studentModel);
                await dbContext.SaveChangesAsync();
                TempData["Update_Success"] = "Student Data Updated Successfully!!!";
                return RedirectToAction("Data", "Home");
            }
            return View(studentModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || dbContext.tbl_StudentUsingEntity == null)
            {
                return NotFound();
            }
            var StudentData = await dbContext.tbl_StudentUsingEntity.FirstOrDefaultAsync(x => x.Id == id);
            if (StudentData == null)
            {
                return NotFound();
            }

            return View(StudentData);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken] // this is prevent data from hacker or who are calling submit from external i.e.csrf
        //Note - if you inspect then chekc at last at submit button there is hiddent tokenbase genrate hidden value it is creating when submit called from this appplication not by outside external/hacker
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null || dbContext.tbl_StudentUsingEntity == null)
            {
                return NotFound();
            }
            var StudentData = await dbContext.tbl_StudentUsingEntity.FindAsync(id);
            if (StudentData != null)
            {
                dbContext.tbl_StudentUsingEntity.Remove(StudentData);
                await dbContext.SaveChangesAsync();
                TempData["Delete_Success"] = "Student Data Deleted Successfully!!!";
                return RedirectToAction("Data", "Home");
            }
            else
            {
                return NotFound();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}