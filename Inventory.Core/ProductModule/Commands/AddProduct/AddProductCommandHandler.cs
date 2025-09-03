using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Inventory.Application.Common.Dtos;
using Inventory.Core.Interfaces;
using Inventory.Domain.Product.Models;
using MediatR;

namespace Inventory.Application.ProductModule.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, RequestResponse<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async  Task<RequestResponse<string>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
             request.Deconstruct(out var requestBody);

               var newProduct = new Product
               {
                   Name = requestBody.Name,
                   AvailableStock = requestBody.Stockquantity,
                   Description = requestBody.Description,
                   Price = requestBody.Price,
               };


             _unitOfWork.Products.Add(newProduct);

            _unitOfWork.Complete();


            return new RequestResponse<string>
            {
                ResponseCode = (int)HttpStatusCode.OK,
                ResponseMessage = "Successful",
                ResponseData = newProduct.Id,

            };



        }
    }
}
