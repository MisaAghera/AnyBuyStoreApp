
using AnyBuyStore.Core.Handlers.OrderDetailsHandler.Commands.AddOrderDetails;
using AnyBuyStore.Core.Handlers.OrderDetailsHandler.Commands.DeleteOrderDetailsCommand;
using AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetAllOrderDetails;
using AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetAllOrderDetailsByOrderId;
using AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetOrderDetailsById;
using AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Commands.UpdateProductSubCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace AnyBuyStore.Controllers
{

    public class OrderDetailsController : BaseApiController
    {
        public OrderDetailsController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllOrderDetailsQuery(), cancellationToken));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetOrderDetailsByIdQuery { Id = Id }, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddOrderDetailsCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteOrderDetailsCommand { Id = id }, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateOrderDetailsCommand command, CancellationToken cancellationToken)
        {
            command.In.Id = id;
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByOrderId(int OrderId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllOrderDetailsByOrderIdQuery { OrderId = OrderId }, cancellationToken));
        }
        
    }

}