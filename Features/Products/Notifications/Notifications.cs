using MediatR;

namespace CQRS_And_MediatR_System.Features.Products;

public record ProductCreatedNotification(Guid Id) : INotification;
