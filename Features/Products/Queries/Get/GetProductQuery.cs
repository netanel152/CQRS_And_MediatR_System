using CQRS_And_MediatR_System.Features.Products.Dtos;
using MediatR;

namespace CQRS_And_MediatR_System.Features.Products.Queries.Get;

public record GetProductQuery(Guid Id) : IRequest<ProductDto>;
