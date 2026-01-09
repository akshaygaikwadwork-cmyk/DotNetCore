using DependecyInjectionWithLooselyCouple.Model;
using Microsoft.AspNetCore.Mvc;

namespace DependecyInjectionWithLooselyCouple.Controllers
{
    public class HomeController : Controller
    {
        //Constructor Dependency Injection
        //=>

        ////Create a reference variable of IStudentRepository
        //private readonly IStudentRepository? _repository = null;
        ////Initialize the variable through constructor
        //public HomeController(IStudentRepository repository)
        //{
        //    _repository = repository;
        //}
        //public JsonResult Index()
        //{
        //    List<Student>? allStudentDetails = _repository?.GetAllStudent();
        //    return Json(allStudentDetails);
        //}
        //public JsonResult GetStudentDetails(int Id)
        //{
        //    Student? studentDetails = _repository?.GetStudentById(Id);
        //    return Json(studentDetails);
        //}

        //--------------------x----------------------------x-----------------------x----------------------------x----------------------

        //Action Method Dependency Injection
        //=>

        //This is useful when a specific service is needed only in a single action method and not throughout the controller

        //public JsonResult Index([FromServices] IStudentRepository repository)
        //{
        //    List<Student> allStudentDetails = repository.GetAllStudent();
        //    return Json(allStudentDetails);
        //}


        //--------------------x----------------------------x-----------------------x----------------------------x----------------------

        //Property Dependency Injection
        //=>

        //public JsonResult Index()
        //{
        //    var services = this.HttpContext.RequestServices;

        //    IStudentRepository? _repository = (IStudentRepository?)services.GetService(typeof(IStudentRepository));
        //    List<Student>? allStudentDetails = _repository?.GetAllStudent();
        //    return Json(allStudentDetails);
        //}
        //public JsonResult GetStudentDetails(int Id)
        //{
        //    var services = this.HttpContext.RequestServices;
        //    IStudentRepository? _repository = (IStudentRepository?)services.GetService(typeof(IStudentRepository));
        //    Student? studentDetails = _repository?.GetStudentById(Id);
        //    return Json(studentDetails);
        //}


        //--------------------x----------------------------x-----------------------x----------------------------x----------------------

        //Diff - Singleton/Scoped/Transient
        //=>

        //Create a reference variable of IStudentRepository
        private readonly IStudentRepository? _repository = null;
        private readonly SomeOtherService? _someOtherService = null;
        //Initialize the variable through constructor
        public HomeController(IStudentRepository repository, SomeOtherService someOtherService)
        {
            _repository = repository;
            _someOtherService = someOtherService;
        }
        public JsonResult Index()
        {
            List<Student>? allStudentDetails = _repository?.GetAllStudent();
            _someOtherService?.SomeMethod();
            return Json(allStudentDetails);
        }
        public JsonResult GetStudentDetails(int Id)
        {
            Student? studentDetails = _repository?.GetStudentById(Id);
            _someOtherService?.SomeMethod();
            return Json(studentDetails);
        }

    }
}
