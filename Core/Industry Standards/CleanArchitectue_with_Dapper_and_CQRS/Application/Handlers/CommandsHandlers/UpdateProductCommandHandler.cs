using Application.Commands;
using Core.I_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CommandsHandlers
{
    public class UpdateProductCommandHandler
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(UpdateProductCommand command)
        {
            if (command.Product == null)
            {
                throw new ArgumentException(nameof(command));
            }
            await _productRepository.UpdateAsync(command.Product);
        }
    }
}
