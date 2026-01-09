using First_WebApi.Configurations;
using First_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace First_WebApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _dbContext;
        public StudentRepository(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StudentRegModel>> GetStudentsList()
        {
            return await _dbContext.tbl_StudentRegData.ToListAsync();

        }
        public async Task<int> AddStudent(StudentRegModel modelObj)
        {
            await _dbContext.tbl_StudentRegData.AddAsync(modelObj);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<StudentRegModel> GetStudentDataById(int Id)
        {
            return await _dbContext.tbl_StudentRegData.FindAsync(Id);
        }
        public async Task<int> UpdateStudent(StudentRegModel modelObj)
        {
            _dbContext.tbl_StudentRegData.Update(modelObj);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteStudent(int Id)
        {
            var StudentData = await _dbContext.tbl_StudentRegData.FindAsync(Id);
            if (StudentData != null)
            {
                _dbContext.tbl_StudentRegData.Remove(StudentData);
            }
            return await _dbContext.SaveChangesAsync();
        }

    }
}
