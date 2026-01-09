
using CQRS_DesignPrin_WebAPI.Data.Queries;
using CQRS_DesignPrin_WebAPI.Models;
using CQRS_DesignPrin_WebAPI.Services;
using MediatR;

namespace CQRS_DesignPrin_WebAPI.Data.Handlers
{
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery, List<EmployeeModel>>
    {
        private readonly IEmployeeService _employeeRepository;

        public GetEmployeeListHandler(IEmployeeService employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeModel>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetEmployeeListAsync();
        }
    }
}
