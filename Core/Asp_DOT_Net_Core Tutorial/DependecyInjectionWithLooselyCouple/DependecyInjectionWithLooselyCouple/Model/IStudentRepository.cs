namespace DependecyInjectionWithLooselyCouple.Model
{
    public interface IStudentRepository
    {
        Student GetStudentById(int StudentId);
        List<Student> GetAllStudent();
    }
}
