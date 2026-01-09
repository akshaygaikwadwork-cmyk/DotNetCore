using RepositoryPattern.Model;

namespace RepositoryPattern.Repository
{
    public class StudentReposi : IStudentReposi
    {
        public List<StudentModel> getAllStudents()
        {
            return DataSource();
        }

        public StudentModel getStudentById(int id)
        {
            return DataSource().FirstOrDefault(x => x.rollNo == id);
        }

        private List<StudentModel> DataSource()
        {
            return new List<StudentModel>()
            {
                new StudentModel() { rollNo = 101, Name="Akshay", Gender="Male", Standard = 12},
                new StudentModel() { rollNo = 102, Name="Ganesh", Gender="Male", Standard = 12},
                new StudentModel() { rollNo = 103, Name="Vivek", Gender="Male", Standard = 12},
                new StudentModel() { rollNo = 104, Name="Pranit", Gender="Male", Standard = 12},
            };
        }
    }
}
