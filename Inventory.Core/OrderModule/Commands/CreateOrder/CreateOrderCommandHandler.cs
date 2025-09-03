using System.Net;
using Inventory.Application.Common.Dtos;
using Inventory.Core.Interfaces;
using Inventory.Domain.Order.Models;
using Inventory.Domain.Product.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Application.OrderModule.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, RequestResponse<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RequestResponse<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            request.Deconstruct(out var requestBody);

            int retryCount = 0;
            const int maxRetries = 3;

            while (retryCount < maxRetries)
            {
                try
                {
                    var products = new List<Product>();
                    decimal total = 0;

                    // ✅ Validate stock & collect products
                    foreach (var item in requestBody.cartItems)
                    {
                        var product = await _unitOfWork.Products.GetByIdAsync(item.productId);
                        if (product == null)
                            return new RequestResponse<string> { ResponseCode = (int)HttpStatusCode.BadRequest, ResponseMessage = $"Product {item.productId} not found" };

                        if (product.AvailableStock < item.quantity)
                            return new RequestResponse<string> { ResponseCode = (int)HttpStatusCode.BadRequest, ResponseMessage = $"Product {item.productId} is out of stock" };

                        products.Add(product);
                    }

                    // ✅ Build Order
                    var order = new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        Items = new List<OrderItem>()
                    };

                    foreach (var item in requestBody.cartItems)
                    {
                        var product = products.First(p => p.Id == item.productId);

                        // Decrease stock
                        product.AvailableStock -= item.quantity;
                        _unitOfWork.Products.Update(product);

                        // Add order item (snapshot price)
                        order.Items.Add(new OrderItem
                        {
                            ProductId = product.Id,
                            Quantity = item.quantity,
                            UnitPrice = product.Price
                        });

                        total += product.Price * item.quantity;
                    }

                    // ✅ Save order
                     _unitOfWork.Orders.Add(order);
                    await _unitOfWork.CompleteAsync(cancellationToken);

                    return new RequestResponse<string>
                    {
                        ResponseCode = (int)HttpStatusCode.OK,
                        ResponseMessage = "Successful",

                    };
                }
                catch (DbUpdateConcurrencyException)
                {
                    retryCount++;

                    if (retryCount >= maxRetries)
                        return new RequestResponse<string>
                    {
                        ResponseCode = (int)HttpStatusCode.InternalServerError,
                        ResponseMessage = "Could not place order due to concurrent updates. Please try again.",

                    };

                    // Reload the conflicting entities before retrying
                    foreach (var entry in requestBody.cartItems)
                    {
                        var product = await _unitOfWork.Products.GetByIdAsync(entry.productId);
                        if (product != null)
                        {
                            await _unitOfWork.ReloadEntityAsync(product);
                        }
                    }
                }
            }

            return new RequestResponse<string>
            {
                ResponseCode = (int)HttpStatusCode.InternalServerError,
                ResponseMessage = "unexpected error occured while making request.",

            };
        }
    }
}
