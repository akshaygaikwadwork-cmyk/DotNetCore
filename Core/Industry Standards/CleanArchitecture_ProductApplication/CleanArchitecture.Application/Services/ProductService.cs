using AutoMapper;
using CleanArchitecture.Application.DTO;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var products = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(products);
        }
        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
        public async Task AddAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.AddAsync(product);
        }
        public async Task UpdateAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateAsync(product);
        }
        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

    }
}
