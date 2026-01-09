using DDDExample.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDExample.Domain.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CreateOrder(string customer, List<(string ProductName, decimal Price, int Quantity)> items)
        {
            var order = new Order(customer);

            foreach (var item in items)
            {
                order.AddItem(item.ProductName, item.Price, item.Quantity);
            }

            await _orderRepository.SaveAsync(order);
        }
    }
}
