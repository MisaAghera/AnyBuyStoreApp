using AnyBuyStore.Core.Handlers.PaymentHandler.commands.paymentWithStripe;
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]PaymentwithStripeCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

    }

}


