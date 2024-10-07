namespace CQRS_And_MediatR_System.Features.Products.Dtos;

public record ProductDto(Guid Id, string Name, string Description, decimal Price);
