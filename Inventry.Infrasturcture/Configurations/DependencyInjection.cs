using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Core.Interfaces;
using Inventory.Infrasturcture.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Infrasturcture.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>))); 
            services.AddTransient<IProductRepository, ProductRepository>(); 
            services.AddTransient<IUnitOfWork, UnitOfWork>();   
            return services;
        }
    }
}
