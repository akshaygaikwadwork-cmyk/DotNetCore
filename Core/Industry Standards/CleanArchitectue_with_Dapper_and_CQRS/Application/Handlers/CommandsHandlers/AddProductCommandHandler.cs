using Application.Commands;
using Core.I_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CommandsHandlers
{
    public class AddProductCommandHandler
    {
        private readonly IProductRepository _productRepository;

        public AddProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(AddProductCommand command)
        {
            if (command.Product == null)
            {
                throw new ArgumentException(nameof(command));
            }
            await _productRepository.AddAsync(command.Product);
        }

    }
}
