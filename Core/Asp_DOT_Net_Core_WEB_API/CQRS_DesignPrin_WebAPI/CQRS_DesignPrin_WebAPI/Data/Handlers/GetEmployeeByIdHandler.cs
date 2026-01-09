using CQRS_DesignPrin_WebAPI.Data.Queries;
using CQRS_DesignPrin_WebAPI.Models;
using CQRS_DesignPrin_WebAPI.Services;
using MediatR;

namespace CQRS_DesignPrin_WebAPI.Data.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeModel>
    {
        private readonly IEmployeeService _employeeRepository;

        public GetEmployeeByIdHandler(IEmployeeService employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeModel> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(request.Id);
        }
    }
}
