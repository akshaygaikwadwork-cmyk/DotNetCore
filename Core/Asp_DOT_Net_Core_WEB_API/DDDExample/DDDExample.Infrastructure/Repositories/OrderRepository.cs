using DDDExample.Domain.Repositories;
using DDDExample.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DDDExample.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task SaveAsync(Order order)
        {
            if (_context.Orders.Any(o => o.Id == order.Id))
            {
                _context.Orders.Update(order);
            }
            else
            {
                await _context.Orders.AddAsync(order);
            }

            await _context.SaveChangesAsync();
        }
    }
}
