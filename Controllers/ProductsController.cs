using CQRS_And_MediatR_System.Features.Products;
using CQRS_And_MediatR_System.Features.Products.Commands.Create;
using CQRS_And_MediatR_System.Features.Products.Commands.Delete;
using CQRS_And_MediatR_System.Features.Products.Commands.Update;
using CQRS_And_MediatR_System.Features.Products.Queries.Get;
using CQRS_And_MediatR_System.Features.Products.Queries.List;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_And_MediatR_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ISender _mediatorSender;
    private readonly IMediator _mediatorPublish;

    public ProductsController(ISender mediatorSender,IMediator mediatorPublish)
    {
        _mediatorSender = mediatorSender;
        _mediatorPublish = mediatorPublish;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var product = await _mediatorSender.Send(new GetProductQuery(id));
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _mediatorSender.Send(new ListProductsQuery());
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        var productId = await _mediatorSender.Send(command);
        if (productId == Guid.Empty)
            return BadRequest();
        await _mediatorPublish.Publish(new ProductCreatedNotification(productId));
        return CreatedAtAction(nameof(GetProduct), new { id = productId }, new { id = productId });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductCommand command)
    {
        if (id != command.Id)
            return BadRequest("Product ID mismatch");

        var result = await _mediatorSender.Send(command);

        if (!result)
            return NotFound();

        return NoContent();
    }


    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        await _mediatorSender.Send(new DeleteProductCommand(id));
        return NoContent();
    }
}
