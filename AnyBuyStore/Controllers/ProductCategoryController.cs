using AnyBuyStore.Core.Handlers.ProductCategoryHandler.Commands.AddProductCategory;
using AnyBuyStore.Core.Handlers.ProductCategoryHandler.Commands.DeleteProductCategory;
using AnyBuyStore.Core.Handlers.ProductCategoryHandler.Commands.UpdateProducCategory;
using AnyBuyStore.Core.Handlers.ProductCategoryHandler.Queries.GetAllProductCategories;
using AnyBuyStore.Core.Handlers.ProductCategoryHandler.Queries.GetById;
using AnyBuyStore.Core.Handlers.ProductCategoryHandler.Queries.GetCategoryFromSubId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnyBuyStore.Controllers
{  
    public class ProductCategoryController : BaseApiController
    {
        public ProductCategoryController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllProductCetgoriesRequest(), cancellationToken));
        }

       
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddProductCategoryCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteProductCategoryCommand { Id = id }, cancellationToken));
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductCategoryCommand command, CancellationToken cancellationToken)
        {
            command.In.Id = id;
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpGet]
        public async Task<IActionResult> GetBySubId(int SubcategoryId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetCategoryFromSubIdQuery { SubcategoryId = SubcategoryId }, cancellationToken));
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetByIdQuery { Id = Id }, cancellationToken);
            if (result != null)
            {
                return Ok(result);

            }
            return BadRequest();
        }


       



    }

}