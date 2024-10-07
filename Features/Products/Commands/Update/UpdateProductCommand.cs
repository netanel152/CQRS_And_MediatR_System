using MediatR;

namespace CQRS_And_MediatR_System.Features.Products.Commands.Update;

public record UpdateProductCommand(Guid Id, string Name, decimal Price) : IRequest<bool>;
