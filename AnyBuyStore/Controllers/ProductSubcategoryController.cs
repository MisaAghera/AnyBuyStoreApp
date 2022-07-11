using AnyBuyStore.Core.Handlers.ProductCategoryHandler.Queries.GetAllProductCategories;
using AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Commands.AddProductSubCategory;
using AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Commands.DeleteProductSubCategory;
using AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Commands.UpdateProductSubCategory;
using AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Queries.GetAllProductSubCategories;
using AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Queries.GetSubcategoryById;
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

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetSubcategoryByIdQuery { Id = Id }, cancellationToken);
            if (result != null)
            {
                return Ok(result);

            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubcategories(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllSubcategories(), cancellationToken));
        }

    }

}


