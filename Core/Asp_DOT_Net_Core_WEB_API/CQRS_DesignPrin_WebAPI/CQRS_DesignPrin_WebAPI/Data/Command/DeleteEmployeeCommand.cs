using MediatR;

namespace CQRS_DesignPrin_WebAPI.Data.Command
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
