using CQRS_DesignPrin_WebAPI.Models;

namespace CQRS_DesignPrin_WebAPI.Services
{
    public interface IEmployeeService
    {
        //Following are the Queries operation because it's follow read operations(select)
        public Task<List<EmployeeModel>> GetEmployeeListAsync();
        public Task<EmployeeModel> GetEmployeeByIdAsync(int id);

        //Following are the Commands operation because it's follow write operations(Insert/Update/Delete)
        public Task<EmployeeModel> AddEmployeeAsync(EmployeeModel employee);
        public Task<int> UpdateEmployeeAsync(EmployeeModel employee);
        public Task<int> DeleteEmployeeAsync(int id);
    }
}
