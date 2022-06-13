using AnyBuyStore.Core.Handlers.ProductWish.Commands.AddProductWish;
using AnyBuyStore.Core.Handlers.ProductWish.Commands.DeleteProductWish;
using AnyBuyStore.Core.Handlers.ProductWish.Queries.GetAllProductWishById;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AnyBuyStore.Core.Handlers.ProductCartHandler.Commands.UpdateProductQuantityInCart;
namespace AnyBuyStore.Controllers
{
   
    public class ProductWishController : BaseApiController
    {
        public ProductWishController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int UserId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllProductWishByUserIdQuery { UserId = UserId }, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductwishCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteProductWishCommand { Id = id }, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductQuantityInCartCommand command, CancellationToken cancellationToken)
        {
            command.In.Id = id;
            return Ok(await _mediator.Send(command, cancellationToken));
        }

    }

}


