using Inventory.Application.OrderModule.Commands.CreateOrder;
using Inventory.Application.OrderModule.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ISender _sender;

        public OrderController(ISender sender)
        {
            _sender = sender;
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody]CreateOrderRequest request)
        {
            var command = new CreateOrderCommand(request);
            var response = await _sender.Send(command); 
            return StatusCode(response.ResponseCode,response);
        }
    }
}
