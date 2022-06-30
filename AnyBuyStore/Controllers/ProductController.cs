using AnyBuyStore.Core.Handlers.ProductHandler.Commands.CreateProduct;
using AnyBuyStore.Core.Handlers.ProductHandler.Commands.DeleteProductById;
using AnyBuyStore.Core.Handlers.ProductHandler.Commands.UpdateProduct;
using AnyBuyStore.Core.Handlers.ProductHandler.Queries.GetAllByUserId;
using AnyBuyStore.Core.Handlers.ProductHandler.Queries.GetAllProducts;
using AnyBuyStore.Core.Handlers.ProductHandler.Queries.GetAllProductsBySubcategory;
using AnyBuyStore.Core.Handlers.ProductHandler.Queries.GetProductById;
using AnyBuyStore.Core.Handlers.ProductHandler.updateProductQuantity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace AnyBuyStore.Controllers
{
    public class ProductController : BaseApiController
    {
        public ProductController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllProductsRequest(), cancellationToken));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductByIdQuery { Id = Id },cancellationToken);
            if (result != null)
            {
                return Ok(result);

            }
            return BadRequest();
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddProductCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteProductCommand { Id = id }, cancellationToken));
        }

        [HttpPut("put")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBySubId(int SubcategoryId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllProductsBySubcategoryQuery { ProductCategoryId = SubcategoryId }, cancellationToken));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByUSerId(int UserId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllByUserIdQuery { UserId = UserId }, cancellationToken));
        }


        [HttpPut("put")]
        public async Task<IActionResult> UpdateQuantity(int id, UpdateProductQuantityCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        

    }

}