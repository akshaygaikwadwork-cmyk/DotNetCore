using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice2.Model;
using Practice2.Repository;
using Practice2.Service;

namespace Practice2.Controllers
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
                List<StudentModel> studentsList =  await _studentService.GetAllStudentList();
                if (studentsList.Count <= 0)
                {
                    return Ok("No Data Found");
                }
                else
                {
                    return Ok(studentsList);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentListById(int id)
        {
            try
            {
                StudentModel studentsList = await _studentService.GetStudentListById(id);
                if (studentsList == null)
                {
                    return Ok("No Data Found");
                }
                else
                {
                    return Ok(studentsList);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(List<StudentModel> student)
        {
            try
            {
                if (student != null)
                {
                   int result =  await _studentService.AddStudent(student);
                    if (result == 0)
                    {
                        return BadRequest("Something went wrong");
                    }
                    else
                    {
                        return Ok("Student Added Successfully");
                    }

                }
                else
                {
                    return BadRequest(student);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(StudentModel student)
        {
            try
            {
                if (student != null)
                {
                    int result = await _studentService.UpdateStudent(student);
                    if (result == 0)
                    {
                        return BadRequest("Something went wrong");
                    }
                    else
                    {
                        return Ok("Student Updated Successfully");
                    }

                }
                else
                {
                    return BadRequest(student);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                if (id > 0)
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
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
