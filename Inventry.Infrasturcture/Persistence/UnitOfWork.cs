using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Application.Interfaces;
using Inventory.Core.Interfaces;
using Inventory.Infrasturcture.Common.DataContext;

namespace Inventory.Infrasturcture.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
          _context = context;
           Products = new ProductRepository(_context);  
           Orders = new OrderRepository(_context);  
           
        }
        public IProductRepository Products { get; private set; }
        public IOrderRepository Orders { get; private set; }    
        public int Complete()
        {
            return _context.SaveChanges();

        }

        public void Dispose()
        {
           _context.Dispose();  
        }
    }
}
