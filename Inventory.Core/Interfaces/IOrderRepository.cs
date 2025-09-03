using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Core.Interfaces;
using Inventory.Domain.Order.Models;

namespace Inventory.Application.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
    }
}
