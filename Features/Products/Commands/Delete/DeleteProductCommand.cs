using MediatR;

namespace CQRS_And_MediatR_System.Features.Products.Commands.Delete;

public record DeleteProductCommand(Guid Id) : IRequest;
