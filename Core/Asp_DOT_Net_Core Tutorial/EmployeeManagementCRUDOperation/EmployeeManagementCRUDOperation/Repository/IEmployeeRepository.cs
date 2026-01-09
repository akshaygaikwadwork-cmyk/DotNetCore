using EmployeeManagementCRUDOperation.Models;

namespace EmployeeManagementCRUDOperation.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> GetEmployeeList();

        Task<List<Department>> GetDepartmentList();

        Task<int> AddEmployee(EmployeeModel employee);
        Task<EmployeeModel> GetEmployeeDetailsById(int id);
        Task<EmployeeModel> GetEmpById_ForEdit(int id);
        Task<int> UpdateEmployee(EmployeeModel employee);
        Task<int> DeleteEmployee(int id);
    }
}
