using CRUD_Operation1.DAL;
using CRUD_Operation1.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operation1.BAL
{
    public class StudentBAL
    {
        private readonly StudentDAL _studentDal;

        public StudentBAL(StudentDAL studentDAL)
        {
            _studentDal = studentDAL;
        }

        public List<StudentModel> GetAllStudent()
        {
            try
            {
                List<StudentModel> StudList = _studentDal.GetAllStudent();
                return StudList;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int AddStudent(StudentModel studentModel)
        {
            try
            {
                return _studentDal.AddStudent(studentModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public StudentModel GetStudentById(int id)
        {
            try
            {
                return _studentDal.GetStudentById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdateStudent(StudentModel studentModel)
        {
            try
            {
                return _studentDal.UpdateStudent(studentModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int DeleteStudent(int id)
        {
            try
            {
                return _studentDal.DeleteStudent(id);
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
