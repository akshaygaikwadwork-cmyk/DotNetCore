using CQRS_DesignPrin_WebAPI.Models;
using MediatR;

namespace CQRS_DesignPrin_WebAPI.Data.Queries
{
    public class GetEmployeeListQuery : IRequest<List<EmployeeModel>> // Return Type
    {

    }
}
