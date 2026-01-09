using DependencyInjectionPractice.Model;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionPractice.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult Index()
        {
            StudentRepository repository = new StudentRepository();
            List<Student> allStudentDetails = repository.GetAllStudent();
            return Json(allStudentDetails);
        }
        public JsonResult GetStudentDetails(int Id)
        {
            StudentRepository repository = new StudentRepository();
            Student studentDetails = repository.GetStudentById(Id);
            return Json(studentDetails);
        }
    }
}
