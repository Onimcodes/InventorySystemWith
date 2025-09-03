using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.ProductModule.Dtos
{
    public  record AddProductDto (decimal Price, int Stockquantity, string Name , string Description);

  

}
