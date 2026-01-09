using EmployeeManagementCRUDOperation.Configuration;
using EmployeeManagementCRUDOperation.Models;
using EmployeeManagementCRUDOperation.Repository;

namespace EmployeeManagementCRUDOperation.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EmployeeModel>> GetEmployeeList()
        {
            return await _repository.GetEmployeeList();
        }

        public async Task<List<Department>> GetDepartmentList()
        {
            return await _repository.GetDepartmentList();
        }

        public async Task<int> AddEmployee(EmployeeModel employee)
        {
            return await _repository.AddEmployee(employee);
        }

        public async Task<EmployeeModel> GetEmployeeDetailsById(int Id)
        {
            return await _repository.GetEmployeeDetailsById(Id);
        }

        public async Task<EmployeeModel> GetEmpById_ForEdit(int Id)
        {
            return await _repository.GetEmpById_ForEdit(Id);
        }

        public async Task<int> UpdateEmployee(EmployeeModel employee)
        {
            return await _repository.UpdateEmployee(employee);
        }
        public async Task<int> DeleteEmployee(int id)
        {
            return await _repository.DeleteEmployee(id);
        }
    }
}
