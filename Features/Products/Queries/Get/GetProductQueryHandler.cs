﻿using CQRS_And_MediatR_System.Features.Products.Dtos;
using CQRS_And_MediatR_System.Persistence;
using MediatR;

namespace CQRS_And_MediatR_System.Features.Products.Queries.Get;

public class GetProductQueryHandler(AppDbContext context)
    : IRequestHandler<GetProductQuery, ProductDto?>
{
    public async Task<ProductDto?> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await context.Products.FindAsync(request.Id);
        if (product == null)
        {
            return null;
        }
        return new ProductDto(product.Id, product.Name, product.Description, product.Price);
    }
}
