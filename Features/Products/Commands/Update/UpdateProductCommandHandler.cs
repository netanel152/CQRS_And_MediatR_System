using CQRS_And_MediatR_System.Persistence;
using MediatR;

namespace CQRS_And_MediatR_System.Features.Products.Commands.Update;

public class UpdateProductCommandHandler(AppDbContext context) : IRequestHandler<UpdateProductCommand, bool>
{
    public async Task<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await context.Products.FindAsync(command.Id);

        if (product == null)
            return false;

        product.Name = command.Name;
        product.Price = command.Price;

        await context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
