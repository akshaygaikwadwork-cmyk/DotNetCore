using CQRS_DesignPrin_WebAPI.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CQRS_DesignPrin_WebAPI.Data.Command
{
    public class CreateEmployeeCommand : IRequest<EmployeeModel>
    {
        public CreateEmployeeCommand(string name, string address, string email, string phone)
        {
            Name = name;
            Address = address;
            Email = email;
            Phone = phone;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
