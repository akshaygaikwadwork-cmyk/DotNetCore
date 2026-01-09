using Microsoft.AspNetCore.Mvc;
using LoginFormWithDatabaseFirstWithSession.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace LoginFormWithDatabaseFirstWithSession.Controllers
{
    public class HomeController : Controller
    {
        public Asp_DOT_NetCore_DBContext _DBContext;

        public HomeController(Asp_DOT_NetCore_DBContext DBContext)
        {
            _DBContext = DBContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Login(TblEmployee empObj)
        {
            var EmpData = await _DBContext.TblEmployees.Where(x => x.EmailId == empObj.EmailId && x.Password == empObj.Password).FirstOrDefaultAsync();
            if (EmpData != null)
            {
                HttpContext.Session.SetString("UserSession", empObj.EmailId);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Message = "Login Failed";
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(TblEmployee empObj)
        {
            if(ModelState.IsValid)
            {
                await _DBContext.TblEmployees.AddAsync(empObj);
                await _DBContext.SaveChangesAsync();
                TempData["Success"] = "Registered Successfully";
                return RedirectToAction("Login");
            }
            return View();
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.UserSessiondata = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}