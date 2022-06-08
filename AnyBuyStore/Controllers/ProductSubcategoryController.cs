using AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Commands.AddProductSubCategory;
using AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Commands.DeleteProductSubCategory;
using AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Commands.UpdateProductSubCategory;
using AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Queries.GetAllProductSubCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnyBuyStore.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductSubcategoryController : BaseApiController
    {
        public ProductSubcategoryController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int CategoryId)
        {
            return Ok(await _mediator.Send(new GetAllProductSubcategoriesQuery { ProductCategoryId = CategoryId }));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductSubcategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteProductSubcategoryCommand { Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductSubcategoryCommand command)
        {
            command.In.Id = id;
            return Ok(await _mediator.Send(command));
        }

    }

}


