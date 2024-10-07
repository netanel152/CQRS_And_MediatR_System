using MediatR;

namespace CQRS_And_MediatR_System.Features.Products.Commands.Create;

public record CreateProductCommand(string Name, string Description, decimal Price) : IRequest<Guid>;

