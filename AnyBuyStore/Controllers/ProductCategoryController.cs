using AnyBuyStore.Core.Handlers.ProductCategoryHandler.Commands.AddProductCategory;
using AnyBuyStore.Core.Handlers.ProductCategoryHandler.Commands.DeleteProductCategory;
using AnyBuyStore.Core.Handlers.ProductCategoryHandler.Commands.UpdateProducCategory;
using AnyBuyStore.Core.Handlers.ProductCategoryHandler.Queries.GetAllProductCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnyBuyStore.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductCategoryController : BaseApiController
    {
        public ProductCategoryController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllProductCetgoriesRequest()));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteProductCategoryCommand{ Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductCategoryCommand command)
        {
            command.In.Id = id;
            return Ok(await _mediator.Send(command));
        }

    }

}