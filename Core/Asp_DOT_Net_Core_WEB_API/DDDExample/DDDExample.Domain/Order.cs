using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDExample.Domain
{
    public class Order
    {
        public Guid Id { get; private set; }
        public string Customer { get; private set; }
        public List<OrderItem> Items { get; private set; }

        public Order(string customer)
        {
            Id = Guid.NewGuid();
            Customer = customer;
            Items = new List<OrderItem>();
        }

        public void AddItem(string productName, decimal price, int quantity)
        {
            var item = new OrderItem(productName, price, quantity);
            Items.Add(item);
        }
    }
}
