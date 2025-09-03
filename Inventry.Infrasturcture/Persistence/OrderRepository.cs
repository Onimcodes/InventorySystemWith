using Inventory.Application.Interfaces;
using Inventory.Domain.Order.Models;
using Inventory.Infrasturcture.Common.DataContext;

namespace Inventory.Infrasturcture.Persistence
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}
