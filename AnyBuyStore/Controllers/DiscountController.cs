
using AnyBuyStore.Core.Handlers.DiscountHandler.Commands.AddDiscount;
using AnyBuyStore.Core.Handlers.DiscountHandler.DeleteDiscount;
using AnyBuyStore.Core.Handlers.DiscountHandler.Queries.GetAllDiscounts;
using AnyBuyStore.Core.Handlers.DiscountHandler.Queries.GetById;
using AnyBuyStore.Core.Handlers.DiscountHandler.Queries.GetProductsByDiscountId;
using AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Commands.UpdateDiscount;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnyBuyStore.Controllers
{
    
    public class DiscountController : BaseApiController
    {
        public DiscountController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet("{DiscountId}")]
        public async Task<IActionResult> GetpProductsById(int DiscountId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetProductsByDiscountIdQuery { DiscountId = DiscountId }, cancellationToken));
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllDiscountsQuery(), cancellationToken));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddDiscountCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteDiscountCommand { Id = id }, cancellationToken));
        }


        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateDiscountCommand command, CancellationToken cancellationToken)
        {
            command.In.Id = id;
            return Ok(await _mediator.Send(command, cancellationToken));
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


