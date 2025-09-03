using System;
using Inventory.Application.Interfaces;

namespace Inventory.Core.Interfaces
{
    public  interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        Task<int> CompleteAsync(CancellationToken cancellationToken = default);
        Task ReloadEntityAsync<TEntity>(TEntity entity) where TEntity : class;
        int Complete();
    }
}
