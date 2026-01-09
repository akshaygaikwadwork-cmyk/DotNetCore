using Microsoft.EntityFrameworkCore;
using Practice1.Data;
using Practice1.Model;

namespace Practice1.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDBContextTest _dBContext;
        public StudentRepository(StudentDBContextTest dBContext)
        {
            _dBContext = dBContext;
        }


        public async Task<List<StudentTemp>> GetAllStudentList()
        {
            try
            {
                List<StudentTemp> List = await _dBContext.studentTemp.ToListAsync();
                return List;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<StudentTemp> GetStudentById(int id)
        {
            try
            {
                StudentTemp student = await _dBContext.studentTemp.Where(i => i.Id == id).FirstOrDefaultAsync();
                return student;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> AddStudent(StudentTemp studentTemp)
        {
            try
            {
                if (studentTemp != null)
                {
                    await _dBContext.studentTemp.AddAsync(studentTemp);
                    return await _dBContext.SaveChangesAsync();
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdateStudent(StudentTemp studentTemp)
        {
            try
            {
                if (studentTemp != null)
                {
                    StudentTemp student = _dBContext.studentTemp.Where(i => i.Id == studentTemp.Id).FirstOrDefault();
                    if (student != null)
                    {
                        student.Name = (string.IsNullOrEmpty(studentTemp.Name) || (student.Name == studentTemp.Name) ? student.Name : studentTemp.Name);
                        student.Age = (studentTemp.Age <= 0 || student.Age == studentTemp.Age ? student.Age : studentTemp.Age);
                        student.Address = (string.IsNullOrEmpty(studentTemp.Address) || (student.Address == studentTemp.Address) ? student.Address : studentTemp.Address);

                        _dBContext.studentTemp.Update(student);
                    }
                    else
                    {
                        return 0;
                    }
                    return await _dBContext.SaveChangesAsync();
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> DeleteStudent(int id)
        {
            try
            {
                StudentTemp student = await _dBContext.studentTemp.Where(i => i.Id == id).FirstOrDefaultAsync();
                if (student != null)
                {
                    _dBContext.studentTemp.Remove(student);
                }
                return await _dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
