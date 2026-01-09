using StudentApplication.Models;

namespace StudentApplication.Respositorys
{
    public interface IStudentRepository
    {
        public int AddStudent(StudentModel obj);
    }
}
