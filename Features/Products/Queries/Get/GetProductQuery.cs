using CQRS_And_MediatR_System.Caching;
using CQRS_And_MediatR_System.Features.Products.Dtos;
using MediatR;

namespace CQRS_And_MediatR_System.Features.Products.Queries.Get;

public record GetProductQuery(Guid Id) : IRequest<ProductDto>, ICacheable
{
    public bool BypassCache => false;
    public string CacheKey => $"product:{Id}";
    public int SlidingExpirationInMinutes => 30;
    public int AbsoluteExpirationInMinutes => 60;
}