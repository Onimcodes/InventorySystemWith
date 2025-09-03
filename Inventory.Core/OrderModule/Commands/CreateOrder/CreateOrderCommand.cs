using Inventory.Application.Common.Dtos;
using Inventory.Application.OrderModule.Dtos;
using MediatR;

namespace Inventory.Application.OrderModule.Commands.CreateOrder
{
    public record CreateOrderCommand(CreateOrderRequest request) : IRequest<RequestResponse<string>>;


}
