using MediatR;
using SIMS.Application.Repositories;
using SIMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SIMS.Application.Products.Queries
{       
    public record ProductDTO(string Name, string Description, decimal Price, int Stock, string Currency, bool IsAvailable);
    public record GetListProductsQuery() : IRequest<Result<List<ProductDTO>>>;
    public class GetListProductsQueryHandler(IProducts _products) : IRequestHandler<GetListProductsQuery, Result<List<ProductDTO>>>
    {
        public async Task<Result<List<ProductDTO>>> Handle(GetListProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _products.GetAllAsync(cancellationToken);
            var productDTOs = products.Select(p => new ProductDTO(
                p.Name,
                p.Description,
                p.Price,
                p.Stock,
                Enum.GetName(typeof(CurrencyType), p.Currency),
                p.IsAvailable
            )).ToList();

            return productDTOs.Any() 
                ? Result<List<ProductDTO>>.Success(productDTOs) 
                : Result<List<ProductDTO>>.Failure("No products found.");
        }
    }
}
