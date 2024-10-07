using CQRS_And_MediatR_System.Features.Products.Dtos;
using MediatR;

namespace CQRS_And_MediatR_System.Features.Products.Queries.List;

public record ListProductsQuery : IRequest<List<ProductDto>>;
