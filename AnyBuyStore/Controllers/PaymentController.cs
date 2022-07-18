using AnyBuyStore.Core.Handlers.PaymentHandler.commands.paymentWithStripe;
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

    public class PaymentController : BaseApiController
    {
        public PaymentController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]PaymentwithStripeCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

    }

}


