using CRUD_Operation1.Data;
using CRUD_Operation1.Models;

namespace CRUD_Operation1.DAL
{
    public class StudentDAL
    {
        private readonly ApplicationDbConetxt _dbContext;

        public StudentDAL(ApplicationDbConetxt dbContext)
        {
            _dbContext = dbContext;
        }

        public List<StudentModel> GetAllStudent()
        {
            try
            {
                List<StudentModel> StudList = _dbContext.tbl_StudentList.ToList();
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
                if (studentModel != null)
                {
                    _dbContext.tbl_StudentList.Add(studentModel);
                }
                return _dbContext.SaveChanges();
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
                StudentModel StudList = _dbContext.tbl_StudentList.Where(i => i.Id == id).FirstOrDefault();
                return StudList;
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
                StudentModel StudList = _dbContext.tbl_StudentList.Where(i => i.Id == studentModel.Id).FirstOrDefault();
                if (StudList != null)
                {
                    studentModel.Name = (string.IsNullOrEmpty(studentModel.Name) || studentModel.Name == StudList.Name) ? StudList.Name : studentModel.Name;
                    studentModel.Address = (string.IsNullOrEmpty(studentModel.Address) || studentModel.Address == StudList.Address) ? StudList.Address : studentModel.Address;
                    _dbContext.tbl_StudentList.Update(studentModel);
                }
                return _dbContext.SaveChanges();
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
                StudentModel StudList = _dbContext.tbl_StudentList.Where(i => i.Id == id).FirstOrDefault();
                if (StudList != null)
                {
                   _dbContext.tbl_StudentList.Remove(StudList);
                }
                return _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
