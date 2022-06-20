using AnyBuyStore.Core.Handlers.ProductHandler.Commands.CreateProduct;
using AnyBuyStore.Core.Handlers.ProductHandler.Commands.DeleteProductById;
using AnyBuyStore.Core.Handlers.ProductHandler.Commands.UpdateProduct;
using AnyBuyStore.Core.Handlers.ProductHandler.Queries.GetAllProducts;
using AnyBuyStore.Core.Handlers.ProductHandler.Queries.GetAllProductsBySubcategory;
using AnyBuyStore.Core.Handlers.ProductHandler.Queries.GetProductById;
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
            return Ok(await _mediator.Send(new GetProductByIdQuery { Id = Id }, cancellationToken));
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
        public async Task<IActionResult> Update(UpdateProductModel ProductModel, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new UpdateProductCommand { productModel = ProductModel }, cancellationToken));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBySubId(int SubcategoryId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllProductsBySubcategoryQuery { ProductCategoryId = SubcategoryId }, cancellationToken));
        }

       

    }

}