using CQRS_DesignPrin_WebAPI.Models;
using MediatR;

namespace CQRS_DesignPrin_WebAPI.Data.Queries
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeModel>
    {
        public int Id { get; set; }
    }
}
