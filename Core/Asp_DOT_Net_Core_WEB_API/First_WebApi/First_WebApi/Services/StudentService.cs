using First_WebApi.Models;
using First_WebApi.Repositories;

namespace First_WebApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentRegModel>> GetStudentsList()
        {
            return await _studentRepository.GetStudentsList();
        }
        public async Task<int> AddStudent(StudentRegModel modelObj)
        {
            int result = await _studentRepository.AddStudent(modelObj);
            return result;
        }
        public async Task<StudentRegModel> GetStudentDataById(int Id)
        {
            var studentData = await _studentRepository.GetStudentDataById(Id);
            return studentData;
        }
        public async Task<int> UpdateStudent(StudentRegModel modelObj)
        {
            int result = await _studentRepository.UpdateStudent(modelObj);
            return result;
        }
        public async Task<int> DeleteStudent(int Id)
        {
            int result = await _studentRepository.DeleteStudent(Id);
            return result;
        }
    }
}
