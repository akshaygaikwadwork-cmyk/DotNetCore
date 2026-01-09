using CQRS_DesignPrin_WebAPI.Data;
using CQRS_DesignPrin_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_DesignPrin_WebAPI.Repositorys
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EmployeeModel>> GetEmployeeListAsync()
        {
            var result = await _dbContext.tbl_EmployeeNew.ToListAsync();
            return result;
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
        {
            var result = await _dbContext.tbl_EmployeeNew.Where(i => i.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<EmployeeModel> AddEmployeeAsync(EmployeeModel employee)
        {
            var result = _dbContext.tbl_EmployeeNew.Add(employee);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> UpdateEmployeeAsync(EmployeeModel employee)
        {
            //var result = await _dbContext.tbl_EmployeeNew.Where(i => i.Id == employee.Id).FirstOrDefaultAsync();
            //if (result != null)
            //{
            //    result.Name = employee.Name;
            //    result.Address = employee.Address;
            //    result.Email = employee.Email;
            //    result.Phone = employee.Phone;

            //    _dbContext.tbl_EmployeeNew.Update(result);
            //}
            _dbContext.tbl_EmployeeNew.Update(employee);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            var result = await _dbContext.tbl_EmployeeNew.Where(i => i.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {

                _dbContext.tbl_EmployeeNew.Remove(result);
            }
            _dbContext.tbl_EmployeeNew.Remove(result);
            return await _dbContext.SaveChangesAsync();
        }

    }
}
