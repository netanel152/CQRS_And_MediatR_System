﻿using MediatR;

namespace CQRS_And_MediatR_System.Features.Products;

public class RandomHandler(ILogger<RandomHandler> logger) : INotificationHandler<ProductCreatedNotification>
{
    public Task Handle(ProductCreatedNotification notification, CancellationToken cancellationToken)
    {
        logger.LogInformation($"handling notification for product creation with id : {notification.Id}. performing random action.");
        return Task.CompletedTask;
    }
}
