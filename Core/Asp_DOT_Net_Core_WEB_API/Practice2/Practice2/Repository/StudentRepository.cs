using Microsoft.EntityFrameworkCore;
using Practice2.Data;
using Practice2.Model;

namespace Practice2.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppliDbContext _dbContext;
        public StudentRepository(AppliDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<StudentModel>> GetAllStudentList()
        {
            try
            {
                List<StudentModel> studentsList = await _dbContext.StudentsTempTbl.ToListAsync();
                return studentsList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<StudentModel> GetStudentListById(int id)
        {
            try
            {
                StudentModel? studentsList = await _dbContext.StudentsTempTbl.Where(i => i.Id == id).FirstOrDefaultAsync();
                return studentsList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> AddStudent(List<StudentModel> student)
        {
            try
            {
                if (student != null)
                {
                    _dbContext.StudentsTempTbl.AddRange(student);
                }
                else
                {
                    return 0;
                }
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateStudent(StudentModel student)
        {
            try
            {
                if (student != null)
                {
                    StudentModel? studentsList = await _dbContext.StudentsTempTbl.Where(i => i.Id == student.Id).FirstOrDefaultAsync();
                    if (studentsList != null)
                    {
                        studentsList.Name = (string.IsNullOrEmpty(student.Name) || student.Name == studentsList.Name) ? studentsList.Name : student.Name;
                        studentsList.Age = (student.Age <= 0|| student.Age == studentsList.Age) ? studentsList.Age : student.Age;
                        studentsList.Address = (string.IsNullOrEmpty(student.Address) || student.Name == studentsList.Address) ? studentsList.Address : student.Address;

                        _dbContext.StudentsTempTbl.Update(studentsList);
                    }
                    else
                    {
                        return 0;
                    }
                }
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteStudent(int id)
        {
            try
            {
                StudentModel? studentsList = await _dbContext.StudentsTempTbl.Where(i => i.Id == id).FirstOrDefaultAsync();
                if (studentsList != null)
                {
                    _dbContext.StudentsTempTbl.Remove(studentsList);
                }
                else
                {
                    return 0;
                }
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
