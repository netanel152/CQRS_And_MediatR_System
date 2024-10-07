using MediatR;

namespace CQRS_And_MediatR_System.Features.Products;

public class StockAssignedHandler(ILogger<StockAssignedHandler> logger) : INotificationHandler<ProductCreatedNotification>
{
    public Task Handle(ProductCreatedNotification notification, CancellationToken cancellationToken)
    {
        logger.LogInformation($"handling notification for product creation with id : {notification.Id}. assigning stocks.");
        return Task.CompletedTask;
    }
}
