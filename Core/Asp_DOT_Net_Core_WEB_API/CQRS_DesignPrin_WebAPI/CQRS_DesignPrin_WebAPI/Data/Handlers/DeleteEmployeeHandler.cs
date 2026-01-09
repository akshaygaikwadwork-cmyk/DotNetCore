using CQRS_DesignPrin_WebAPI.Data.Command;
using CQRS_DesignPrin_WebAPI.Data.Queries;
using CQRS_DesignPrin_WebAPI.Models;
using CQRS_DesignPrin_WebAPI.Services;
using MediatR;

namespace CQRS_DesignPrin_WebAPI.Data.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, int>
    {
        private readonly IEmployeeService _employeeRepository;

        public DeleteEmployeeHandler(IEmployeeService employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(request.Id);
            if (employee == null) return default;
            return await _employeeRepository.DeleteEmployeeAsync(request.Id);
        }
    }
}
