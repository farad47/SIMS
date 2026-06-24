using MediatR;
using SIMS.Application.Repositories;
using SIMS.Core;
using SIMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS.Application.Products.Commands
{
    public record ProductResponse(Guid id, string name);
    public record CreateProductCommand(string name, string description, decimal price, int stock, string currency) : IRequest<Result<ProductResponse>>;
    public class CreateProductCommandHandler(IProducts _products) : IRequestHandler<CreateProductCommand, Result<ProductResponse>>
    {
        public async Task<Result<ProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.name, request.description, request.price, request.currency, request.stock);
            await _products.AddAsync(product, cancellationToken);
            return Result<ProductResponse>.Success(new ProductResponse(product.Id, product.Name));
        }
    }
}
