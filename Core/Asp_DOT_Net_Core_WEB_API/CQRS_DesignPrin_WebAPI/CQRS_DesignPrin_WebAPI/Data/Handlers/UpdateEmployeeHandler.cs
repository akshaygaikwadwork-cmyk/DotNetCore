using CQRS_DesignPrin_WebAPI.Data.Command;
using CQRS_DesignPrin_WebAPI.Models;
using CQRS_DesignPrin_WebAPI.Services;
using MediatR;

namespace CQRS_DesignPrin_WebAPI.Data.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, int>
    {
        private readonly IEmployeeService _employeeRepository;

        public UpdateEmployeeHandler(IEmployeeService employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(request.Id);
            if (employee == null) return default;
            employee.Name = (string.IsNullOrEmpty(request.Name) || request.Name == employee.Name ? employee.Name : request.Name);
            employee.Address = (string.IsNullOrEmpty(request.Address) || request.Address == employee.Address ? employee.Address : request.Address);
            employee.Email = (string.IsNullOrEmpty(request.Email) || request.Email == employee.Email ? employee.Email : request.Email);
            employee.Phone = (string.IsNullOrEmpty(request.Phone) || request.Phone == employee.Phone ? employee.Phone : request.Phone);
            return await _employeeRepository.UpdateEmployeeAsync(employee);
        }
    }
}
