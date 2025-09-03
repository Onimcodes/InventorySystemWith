using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Domain.Product.Models;

namespace Inventory.Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {

    }
}
