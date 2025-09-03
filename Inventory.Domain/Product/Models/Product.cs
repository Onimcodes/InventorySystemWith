using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Domain.Order.Models;

namespace Inventory.Domain.Product.Models
{
    public class Product
    {
        public string Id { get; set; }   = Guid.NewGuid().ToString();
        public string Name { get; set; }    
        public string Description { get; set; }
        public decimal Price { get; set; }  
        public int AvailableStock { get; set; }
      

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
