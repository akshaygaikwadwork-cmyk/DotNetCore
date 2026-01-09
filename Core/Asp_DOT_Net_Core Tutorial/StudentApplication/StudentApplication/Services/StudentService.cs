using StudentApplication.Models;
using StudentApplication.Respositorys;

namespace StudentApplication.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public int AddStudent(StudentModel obj)
        {
            return _studentRepository.AddStudent(obj);
        }
    }
}
