using CRUD_Operation1.BAL;
using CRUD_Operation1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operation1.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentBAL _studentBAL;
        private readonly ErrorResponse _errorResponse;

        public StudentController(StudentBAL studentBAL, ErrorResponse errorResponse)
        {
            _studentBAL = studentBAL;
            _errorResponse = errorResponse;
        }

        [HttpGet]
        public IActionResult Index(ErrorResponse errorResponse)
        {
            TempViewModel obj = new TempViewModel();
            try
            {
                List<StudentModel> studentList = _studentBAL.GetAllStudent();

                obj.Student = studentList;
                obj.Response = errorResponse;

                return View(obj);
            }
            catch (Exception ex)
            {
                errorResponse.Message = ex.Message;
                return new JsonResult(errorResponse);
            }
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new JsonResult(message);
            }
        }

        [HttpPost]
        public IActionResult AddStudent(StudentModel student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int result = _studentBAL.AddStudent(student);
                    _errorResponse.Message = "Student Added Successfully!!!";
                    return RedirectToAction("Index", _errorResponse);
                }
                return View(student);
            }
            catch (Exception ex)
            {
                _errorResponse.Message = ex.Message;
                return new JsonResult(_errorResponse);
            }
        }

        [HttpGet]
        public IActionResult GetStudentDetails(int id)
        {
            try
            {
                StudentModel obj = new StudentModel();
                if (id > 0)
                {
                    obj = _studentBAL.GetStudentById(id);
                }
                return View(obj);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new JsonResult(message);
            }
        }

        [HttpGet]
        public IActionResult EditStudent(StudentModel student)
        {
            try
            {
                if (student.Id > 0)
                {
                    student = _studentBAL.GetStudentById(student.Id);
                }
                return View(student);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new JsonResult(message);
            }
        }

        [HttpPost]
        public IActionResult UpdateData(StudentModel student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int result = _studentBAL.UpdateStudent(student);
                    _errorResponse.Message = "Student Updated Successfully!!!";
                    return RedirectToAction("Index", _errorResponse);
                }
                return View(student);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new JsonResult(message);
            }
        }


        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                int result = _studentBAL.DeleteStudent(id);
                _errorResponse.Message = "Student Deleted Successfully!!!";
                return RedirectToAction("Index", _errorResponse);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new JsonResult(message);
            }
        }
    }
}
