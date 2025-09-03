using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Application.Common.Dtos;
using Inventory.Domain.Product.Models;
using MediatR;

namespace Inventory.Application.ProductModule.Queries.GetAllProducts
{
    public record GetProductsQuery() : IRequest<RequestResponse<List<Product>>>;
   
}
