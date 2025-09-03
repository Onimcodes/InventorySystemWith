using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Core.Interfaces;
using Inventory.Domain.Product.Models;
using Inventory.Infrasturcture.Common.DataContext;

namespace Inventory.Infrasturcture.Persistence
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
