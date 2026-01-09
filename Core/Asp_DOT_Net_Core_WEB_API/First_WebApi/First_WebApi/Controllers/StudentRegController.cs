using First_WebApi.Models;
using First_WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace First_WebApi.Controllers
{
    public class StudentRegController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentRegController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("StudentList")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var studentList = await _studentService.GetStudentsList();
                return Ok(studentList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("InsertStudent")]
        public async Task<IActionResult> InsertStudent(StudentRegModel modelObj)
        {
            if (ModelState.IsValid)
            {
                int Result = await _studentService.AddStudent(modelObj);
                if (Result > 0)
                {
                    return Ok(Result);
                }
                else
                {
                    return BadRequest();
                }


            }
            else
            {
                return BadRequest(ModelState);
            }


        }

        [HttpGet]
        [Route("GetStudentById")]
        public async Task<IActionResult> GetStudentById(int Id)
        {
            var studentDataById = await _studentService.GetStudentDataById(Id);
            return Ok(studentDataById);
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(StudentRegModel modelObj)
        {
            if (ModelState.IsValid)
            {
                int Result = await _studentService.UpdateStudent(modelObj);
                if (Result > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            int Result = await _studentService.DeleteStudent(Id);
            if (Result > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
