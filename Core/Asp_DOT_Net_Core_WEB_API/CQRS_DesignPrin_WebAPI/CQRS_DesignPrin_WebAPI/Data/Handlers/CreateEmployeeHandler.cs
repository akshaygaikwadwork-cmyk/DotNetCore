using CQRS_DesignPrin_WebAPI.Data.Command;
using CQRS_DesignPrin_WebAPI.Data.Queries;
using CQRS_DesignPrin_WebAPI.Models;
using CQRS_DesignPrin_WebAPI.Services;
using MediatR;

namespace CQRS_DesignPrin_WebAPI.Data.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeModel>
    {
        private readonly IEmployeeService _employeeRepository;

        public CreateEmployeeHandler(IEmployeeService employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeModel> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            EmployeeModel emp = new EmployeeModel()
            {
                Name = request.Name,
                Address = request.Address,
                Email = request.Email,
                Phone = request.Phone
            };
            return await _employeeRepository.AddEmployeeAsync(emp);
        }
    }
}
