using AnyBuyStore.Core.Handlers.ProductCartHandler.Commands.AddProductToCart;
using AnyBuyStore.Core.Handlers.ProductCartHandler.Commands.DeleteCartFromUserId;
using AnyBuyStore.Core.Handlers.ProductCartHandler.Commands.DeleteProductFromCart;
using AnyBuyStore.Core.Handlers.ProductCartHandler.Commands.UpdateProductQuantityInCart;
using AnyBuyStore.Core.Handlers.ProductCartHandler.Queries.GetAllCartProductsById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnyBuyStore.Controllers
{
   
    public class ProductCartController : BaseApiController
    {
        public ProductCartController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll(int UserId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllCartProductByIdQuery { UserId = UserId }, cancellationToken));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddProductToCartCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteProductFromCartCommand { Id = id }, cancellationToken));
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductQuantityInCartCommand command, CancellationToken cancellationToken)
        {
            command.In.Id = id;
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFromUserId(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteCartFromUserIdCommand { userId = id }, cancellationToken));
        }
        

    }

}


