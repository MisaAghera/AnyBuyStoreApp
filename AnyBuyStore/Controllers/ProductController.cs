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
using ProductModel = AnyBuyStore.Core.Handlers.ProductHandler.Commands.CreateProduct.ProductModel;

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
            var result = await _mediator.Send(new GetProductByIdQuery { Id = Id }, cancellationToken);
            if (result != null)
            {
                return Ok(result);

            }
            return BadRequest();
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ProductModel ProductModel, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new AddProductCommand { ProductModel = ProductModel }, cancellationToken));
        }


        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteProductCommand { Id = id }, cancellationToken));
        }

        [Authorize]
        [HttpPut("put")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateProductModel ProductModel, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new UpdateProductCommand { ProductModel = ProductModel }, cancellationToken));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBySubId(int SubcategoryId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllProductsBySubcategoryQuery { ProductCategoryId = SubcategoryId }, cancellationToken));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllByUSerId(int UserId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllByUserIdQuery { UserId = UserId }, cancellationToken));
        }


        [Authorize]
        [HttpPut("put")]
        public async Task<IActionResult> UpdateQuantity(int id, UpdateProductQuantityCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

    }

}

