using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice1.Model;
using Practice1.Service;

namespace Practice1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public HomeController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentList()
        {
            try
            {
                List<StudentTemp> studentsList = await _studentService.GetAllStudentList();
                if (studentsList.Count <= 0)
                {
                    return Ok("No Data Found");
                }
                return Ok(studentsList);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                StudentTemp student = await _studentService.GetStudentById(id);
                if (student == null)
                {
                    return Ok("No Data Found");
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentTemp studentTemp)
        {
            try
            {
                if (studentTemp == null)
                {
                    return BadRequest();
                }
                else
                {
                    int result = await _studentService.AddStudent(studentTemp);
                    if (result == 0)
                    {
                        return BadRequest("Something went wrong");
                    }
                    else
                    {
                        return Ok("Student Added Successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(StudentTemp studentTemp)
        {
            try
            {
                if (studentTemp == null)
                {
                    return BadRequest();
                }
                else
                {
                    int result = await _studentService.UpdateStudent(studentTemp);
                    if (result == 0)
                    {
                        return BadRequest("Something went wrong");
                    }
                    else
                    {
                        return Ok("Student Updated Successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            else
            {
                int result = await _studentService.DeleteStudent(id);
                if (result == 0)
                {
                    return BadRequest("Something went wrong");
                }
                else
                {
                    return Ok("Student Deleted Successfully");
                }
            }
        }
    }
}
