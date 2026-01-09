using Practice1.Model;

namespace Practice1.Service
{
    public interface IStudentService
    {
        Task<List<StudentTemp>> GetAllStudentList();

        Task<StudentTemp> GetStudentById(int id);

        Task<int> AddStudent(StudentTemp studentTemp);

        Task<int> UpdateStudent(StudentTemp studentTemp);

        Task<int> DeleteStudent(int id);
    }
}
