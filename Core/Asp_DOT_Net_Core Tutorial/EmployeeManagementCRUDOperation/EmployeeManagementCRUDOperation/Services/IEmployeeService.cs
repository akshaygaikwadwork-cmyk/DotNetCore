using EmployeeManagementCRUDOperation.Models;

namespace EmployeeManagementCRUDOperation.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeModel>> GetEmployeeList();

        Task<List<Department>> GetDepartmentList();
        Task<int> AddEmployee(EmployeeModel employee);
        Task<int> UpdateEmployee(EmployeeModel employee);
        Task<EmployeeModel> GetEmployeeDetailsById(int id);
        Task<EmployeeModel> GetEmpById_ForEdit(int id);

        Task<int> DeleteEmployee(int id);
    }
}
