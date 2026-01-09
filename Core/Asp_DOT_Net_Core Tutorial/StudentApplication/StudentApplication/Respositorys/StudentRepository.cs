using StudentApplication.Data;
using StudentApplication.Models;

namespace StudentApplication.Respositorys
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddStudent(StudentModel obj)
        {
            try
            {
                if (obj != null)
                {
                    _dbContext.tbl_StudentNew.Add(obj);
                }
                else
                {
                    return 0;
                }
                return _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
