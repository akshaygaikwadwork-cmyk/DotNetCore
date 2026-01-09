using Application.Queries;
using Common.Exceptions;
using Core.Entities;
using Core.I_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.QueriesHandlers
{
    public class GetProductByIdQueryHandler
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductByIdQuery query)
        {
            var abc = await _productRepository.GetByIdAsync(query.Id);
            if (abc != null)
            {
                return abc;
            }
            else
            {
                throw new ProductNotFoundException(query.Id);
            }
        }
    }
}
