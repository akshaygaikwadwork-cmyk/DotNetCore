using CQRS_DesignPrin_WebAPI.Data;
using CQRS_DesignPrin_WebAPI.Models;
using CQRS_DesignPrin_WebAPI.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace CQRS_DesignPrin_WebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EmployeeModel>> GetEmployeeListAsync()
        {
            return await _repository.GetEmployeeListAsync();
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
        {
            return await _repository.GetEmployeeByIdAsync(id);
        }

        public async Task<EmployeeModel> AddEmployeeAsync(EmployeeModel employee)
        {
            return await _repository.AddEmployeeAsync(employee);
        }

        public async Task<int> UpdateEmployeeAsync(EmployeeModel employee)
        {
            return await _repository.UpdateEmployeeAsync(employee);
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            return await _repository.DeleteEmployeeAsync(id);
        }

    }
}
