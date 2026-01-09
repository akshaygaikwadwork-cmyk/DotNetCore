using Application.Requests;
using Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class ProductServiceHandler : IRequestHandler<ProductServiceRequest, object>
    {
        private readonly ProductService _productService;

        public ProductServiceHandler(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<object> Handle(ProductServiceRequest request, CancellationToken cancellationToken)
        {
            switch (request.Operation)
            {
                case ProductServiceOperation.GetById:
                    return await _productService.GetByIdAsync(request.Id);
                case ProductServiceOperation.GetAll:
                    return await _productService.GetAllAsync();
                case ProductServiceOperation.Add:
                    request.resultCount = await _productService.AddAsync(request.ProductDto);
                    return request;
                case ProductServiceOperation.Update:
                    request.resultCount = await _productService.UpdateAsync(request.ProductDto);
                    return request;
                case ProductServiceOperation.Delete:
                    request.resultCount = await _productService.DeleteAsync(request.Id);
                    return request;
                default:
                    throw new InvalidOperationException("Invalid operation");
            }
        }
    }
}
