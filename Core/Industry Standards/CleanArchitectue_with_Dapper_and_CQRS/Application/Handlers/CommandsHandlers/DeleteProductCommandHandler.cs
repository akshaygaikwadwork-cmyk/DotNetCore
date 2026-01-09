using Application.Commands;
using Core.I_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CommandsHandlers
{
    public class DeleteProductCommandHandler
    {
        public readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(DeleteProductCommand command)
        {
            if (command.Id <= 0)
            {
                throw new ArgumentException(nameof(command.Id));
            }
            await _productRepository.DeleteAsync(command.Id);
        }
    }
}
