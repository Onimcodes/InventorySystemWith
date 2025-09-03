using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.OrderModule.Dtos
{
    public record CartItemDto(string productId, int quantity);
  
}
