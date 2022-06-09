using AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Commands.AddProductSubCategory;
using AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Commands.DeleteProductSubCategory;
using AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Commands.UpdateProductSubCategory;
using AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Queries.GetAllProductSubCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnyBuyStore.Controllers
{
    
    public class ProductSubcategoryController : BaseApiController
    {
        public ProductSubcategoryController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int CategoryId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllProductSubcategoriesQuery { ProductCategoryId = CategoryId }, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductSubcategoryCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteProductSubcategoryCommand { Id = id }, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductSubcategoryCommand command, CancellationToken cancellationToken)
        {
            command.In.Id = id;
            return Ok(await _mediator.Send(command, cancellationToken));
        }

    }

}


