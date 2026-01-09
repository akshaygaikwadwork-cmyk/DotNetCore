using BindDDLWithDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace BindDDLWithDB.Controllers
{
    public class HomeController : Controller
    {
        public readonly Asp_DOT_NetCore_DBContext _Context;

        public HomeController(Asp_DOT_NetCore_DBContext context)
        {
            _Context = context;
        }
        private StudentModel BindDDL()
        {
            StudentModel StuModelObj = new StudentModel();
            StuModelObj.StudentList = new List<SelectListItem>();

            var data = _Context.TblStudentUsingEntities.ToList();

            StuModelObj.StudentList.Add(new SelectListItem
            {
                Text = "Select Name",
                Value = ""
            });

            foreach (var item in data)
            {
                StuModelObj.StudentList.Add(new SelectListItem
                {
                    Text = item.StudName,
                    Value = item.Id.ToString()
                });
            }
            return StuModelObj;
        }
        public IActionResult Index()
        {
            var data = BindDDL();   
            return View(data);
        }

        [HttpPost]
        public IActionResult Index(StudentModel ModelObj)
        {
            var student = _Context.TblStudentUsingEntities.Where(x => x.Id == ModelObj.Id).FirstOrDefault();
            if (student != null)
            {
                ViewBag.SelectedValue = student.StudName;
            }
            var data = BindDDL();
            return View(data);
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}