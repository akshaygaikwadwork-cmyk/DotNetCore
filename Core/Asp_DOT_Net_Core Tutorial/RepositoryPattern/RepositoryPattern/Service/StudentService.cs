using RepositoryPattern.Model;
using RepositoryPattern.Repository;

namespace RepositoryPattern.Service;

public class StudentService : IStudentService
{
    private readonly IStudentReposi _studentRepo;

    public StudentService(IStudentReposi studentReposi)
    {
        _studentRepo = studentReposi;
    }

    public List<StudentModel> getAllStudents()
    {
        return _studentRepo.getAllStudents();
    }

    public StudentModel getStudentById(int id)
    {
        return _studentRepo.getStudentById(id);
    }

}
