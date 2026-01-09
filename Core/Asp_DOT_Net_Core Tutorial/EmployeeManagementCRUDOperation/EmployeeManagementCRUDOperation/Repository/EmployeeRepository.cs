using EmployeeManagementCRUDOperation.Configuration;
using EmployeeManagementCRUDOperation.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementCRUDOperation.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            _employeeDbContext = dbContext;
        }

        public async Task<List<EmployeeModel>> GetEmployeeList()
        {
            
            return await _employeeDbContext.tbl_employeeData
                   .Where(x => x.is_deleted == 0)
                   .OrderByDescending(x=>x.Id)
                   .ToListAsync();
        }

        public async Task<List<Department>> GetDepartmentList()
        {
            return await _employeeDbContext.tbl_Department.ToListAsync();
        }
        public async Task<int> AddEmployee(EmployeeModel employee)
        {
            try
            {
                employee.CreatedOn = DateTime.Now;
                _employeeDbContext.tbl_employeeData.Add(employee);
                return await _employeeDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return int.Parse(ex.Message);
            }

        }

        public async Task<EmployeeModel> GetEmployeeDetailsById(int Id)
        {
            var empDetailsList = await _employeeDbContext.tbl_employeeData.FindAsync(Id);
            EmployeeModel obj = new EmployeeModel();
            if (empDetailsList != null)
            {
                obj = empDetailsList;
            }
            return obj;

        }

        public async Task<EmployeeModel> GetEmpById_ForEdit(int Id)
        {
            var empDetailsList = await _employeeDbContext.tbl_employeeData.FindAsync(Id);
            EmployeeModel obj = new EmployeeModel();
            if (empDetailsList != null)
            {
                obj = empDetailsList;
            }
            return obj;
        }

        public async Task<int> UpdateEmployee(EmployeeModel employee)
        {
            _employeeDbContext.tbl_employeeData.Update(employee);
            return await _employeeDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteEmployee(int Id)
        {
            var user = await _employeeDbContext.tbl_employeeData.FindAsync(Id);
            if (user != null)
            {
                user.is_deleted = 1;
                _employeeDbContext.tbl_employeeData.Update(user);
                return await _employeeDbContext.SaveChangesAsync();
            }
            return await _employeeDbContext.SaveChangesAsync();
        }
    }
}
