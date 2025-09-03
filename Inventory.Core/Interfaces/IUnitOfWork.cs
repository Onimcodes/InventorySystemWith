using Inventory.Application.Interfaces;

namespace Inventory.Core.Interfaces
{
    public  interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }    
        int Complete();
    }
}
