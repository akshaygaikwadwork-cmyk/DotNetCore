using Practice2.Data;
using Practice2.Model;
using Practice2.Repository;

namespace Practice2.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<List<StudentModel>> GetAllStudentList()
        {
            try
            {
                return await _studentRepository.GetAllStudentList();
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
                return await _studentRepository.GetStudentListById(id);
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
                    return await _studentRepository.AddStudent(student);
                }
                else
                {
                    return 0;
                }
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
                    return await _studentRepository.UpdateStudent(student);
                }
                else
                {
                    return 0;
                }
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
                if (id > 0)
                {
                    return await _studentRepository.DeleteStudent(id);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
