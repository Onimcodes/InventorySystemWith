using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Application.Common.Dtos;
using Inventory.Application.ProductModule.Dtos;
using MediatR;

namespace Inventory.Application.ProductModule.Commands.AddProduct
{
    public record AddProductCommand (AddProductDto request) : IRequest<RequestResponse<string>>;
  
}
