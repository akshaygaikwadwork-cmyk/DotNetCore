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
    public class GetAllProductsQueryHandler
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query)
        {
            var product = await _productRepository.GetAllAsync();
            if (product == null)
                throw new NullReferenceException();

            return product;
        }
    }
}
