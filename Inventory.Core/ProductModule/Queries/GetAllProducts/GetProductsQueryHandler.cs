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

namespace Inventory.Application.ProductModule.Queries.GetAllProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, RequestResponse<List<Product>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RequestResponse<List<Product>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return new RequestResponse<List<Product>>
            {
                ResponseCode = (int)HttpStatusCode.OK,
                ResponseMessage = "Successful",
                ResponseData = products
            };
        }
    }
}
