using RepositoryPattern.Model;

namespace RepositoryPattern.Service;

public interface IStudentService
{
    List<StudentModel> getAllStudents();
    StudentModel getStudentById(int id);
}
