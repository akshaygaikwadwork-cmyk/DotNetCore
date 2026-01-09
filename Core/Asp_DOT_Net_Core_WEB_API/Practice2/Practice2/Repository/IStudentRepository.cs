using Practice2.Model;

namespace Practice2.Repository
{
    public interface IStudentRepository
    {
        public Task<List<StudentModel>> GetAllStudentList();
        public Task<StudentModel> GetStudentListById(int id);
        public Task<int> AddStudent(List<StudentModel> student);
        public Task<int> UpdateStudent(StudentModel student);
        public Task<int> DeleteStudent(int id);
    }
}
