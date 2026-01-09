using CRUD_WithWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_WithWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        public readonly Asp_DOT_NetCore_DBContext _context;
        public StudentAPIController(Asp_DOT_NetCore_DBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TblStudentUsingEntity>>> GetStudents()
        {
            var data = await _context.TblStudentUsingEntities.ToListAsync();
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblStudentUsingEntity>> GetStudentById(int id)
        {
            var data = await _context.TblStudentUsingEntities.FindAsync(id);
            if (data == null)
            {
                 return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TblStudentUsingEntity>> CreateStudent(TblStudentUsingEntity modelObj)
        {
            await _context.TblStudentUsingEntities.AddAsync(modelObj);
            await _context.SaveChangesAsync();
            return Ok(modelObj);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TblStudentUsingEntity>> UpdateStudent(int id, TblStudentUsingEntity modelObj)
        {
            if(id != modelObj.Id)
            {
                return BadRequest();
            }
            else
            {
                _context.Entry(modelObj).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(modelObj);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TblStudentUsingEntity>> DeleteStudent(int id)
        {
            var data = await _context.TblStudentUsingEntities.FindAsync(id);
            if(data == null)
            {
                return NotFound();
            }
            else
            {
                _context.TblStudentUsingEntities.Remove(data);
                await _context.SaveChangesAsync();
                return Ok(data);
            }
        }
    }
}
