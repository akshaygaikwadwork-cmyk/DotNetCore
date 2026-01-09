using Microsoft.EntityFrameworkCore;
using Practice1.Model;
using Practice1.Repository;

namespace Practice1.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository) 
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentTemp>> GetAllStudentList()
        {
            try
            {
                return await _studentRepository.GetAllStudentList();
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
                return await _studentRepository.GetStudentById(id);
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
                return await _studentRepository.AddStudent(studentTemp);
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
                return await _studentRepository.UpdateStudent(studentTemp);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> DeleteStudent(int id)
        {
            return await _studentRepository.DeleteStudent(id);
        }

    }
}
