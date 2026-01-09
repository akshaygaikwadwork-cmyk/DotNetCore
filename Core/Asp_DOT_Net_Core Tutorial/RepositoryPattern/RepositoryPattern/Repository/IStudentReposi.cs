using RepositoryPattern.Model;

namespace RepositoryPattern.Repository
{
    public interface IStudentReposi
    {
        List<StudentModel> getAllStudents();
        StudentModel getStudentById(int id);
    }
}
