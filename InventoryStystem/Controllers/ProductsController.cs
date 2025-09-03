using Inventory.Application.ProductModule.Commands.AddProduct;
using Inventory.Application.ProductModule.Dtos;
using Inventory.Application.ProductModule.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;

     
        public ProductsController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost]

        public async Task<IActionResult> AddProduct([FromBody] AddProductDto request)
        {
            var command = new AddProductCommand(request);
           var commandResponse = await  _sender.Send(command);
            return StatusCode(commandResponse.ResponseCode, commandResponse);
        }

        [HttpGet]

        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetProductsQuery();
            var response = await _sender.Send(query);   
            return StatusCode(response.ResponseCode, response);
        }

    }
}
