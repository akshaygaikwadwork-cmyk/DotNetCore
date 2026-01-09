using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Model;
using RepositoryPattern.Repository;
using RepositoryPattern.Service;

namespace RepositoryPattern.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IStudentService _studentService;

        public HomeController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Student")]
        public IActionResult GetAllStudents()
        {
            var list = _studentService.getAllStudents();
            return Json(list);
        }

        [HttpGet("Student/{id}")]
        public IActionResult getStudentById(int id)
        {
            var student = _studentService.getStudentById(id);
            if (student == null)
                return NotFound();

            return Json(student);
        }
    }
}
