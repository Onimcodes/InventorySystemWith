using Inventory.Application.Common.Dtos;
using Inventory.Core.Interfaces;
using Inventory.Domain.Order.Models;
using Inventory.Domain.Product.Models;
using MediatR;

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
            bool saved = false;
            while(!saved)
            {
                try
                {
                    var products = new List<Product>();

                    decimal total = 0;
                    foreach(var item in requestBody.cartItems)
                    {
                        var product = await  _unitOfWork.Products.GetByIdAsync(item.productId);


                        if (product == null)
                            throw new InvalidOperationException($"Product {item.productId} not found");

                        if (product.AvailableStock < item.quantity)
                            throw new InvalidOperationException($"Not enough stock for {product.Name}");

                        products.Add( product );    

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
                        _unitOfWork.Repository<Product>().Update(product);

                        // Add order item (snapshot price)
                        order.Items.Add(new OrderItem
                        {
                            ProductId = product.Id,
                            Quantity = item.Quantity,
                            UnitPrice = product.Price
                        });

                        total += product.Price * item.Quantity;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
