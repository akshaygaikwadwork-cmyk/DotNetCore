using Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests
{
    public class ProductServiceRequest : IRequest<object>
    {
        public int Id { get; set; }
        public ProductDto ProductDto { get; set; }
        public ProductServiceOperation Operation { get; set; }

        public int resultCount { get; set; }
    }

    public enum ProductServiceOperation
    {
        GetById,
        GetAll,
        Add,
        Update,
        Delete
    }

}
