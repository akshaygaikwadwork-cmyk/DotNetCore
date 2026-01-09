using CQRS_DesignPrin_WebAPI.Data.Command;
using CQRS_DesignPrin_WebAPI.Data.Queries;
using CQRS_DesignPrin_WebAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_DesignPrin_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<EmployeeModel>> EmployeeList()
        {
            var employeeList = await _mediator.Send(new GetEmployeeListQuery());
            return employeeList;
        }

        [HttpGet("{id}")]
        public async Task<EmployeeModel> EmployeeById(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery() { Id = id });
            return employee;
        }

        [HttpPost]
        public async Task<EmployeeModel> AddEmployee(EmployeeModel employee)
        {
            var employeeReturn = await _mediator.Send(new CreateEmployeeCommand(employee.Name, employee.Address, employee.Email, employee.Phone));
            return employeeReturn;
        }

        [HttpPut]
        public async Task<int> UpdateEmployee(EmployeeModel employee)
        {
            var employeeReturn = await _mediator.Send(new UpdateEmployeeCommand(employee.Id, employee.Name, employee.Address, employee.Email, employee.Phone));
            return employeeReturn;
        }

        [HttpDelete("{id}")]
        public async Task<int> DeleteEmployee(int id)
        {
            var employeeReturn = await _mediator.Send(new DeleteEmployeeCommand() { Id = id });
            return employeeReturn;
        }

    }
}
