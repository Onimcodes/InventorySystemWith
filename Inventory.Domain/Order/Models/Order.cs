using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Order.Models
{
    public class Order
    {
        public string Id { get; set; }  = Guid.NewGuid().ToString();
        public decimal Amount { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }
        // Navigation property
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
