using First_WebApi.Models;

namespace First_WebApi.Repositories
{
    public interface IStudentRepository
    {
        Task<List<StudentRegModel>> GetStudentsList();
        Task<int> AddStudent(StudentRegModel modelObj);
        Task<StudentRegModel> GetStudentDataById(int Id);
        Task<int> UpdateStudent(StudentRegModel modelObj);
        Task<int> DeleteStudent(int Id);

    }
}
