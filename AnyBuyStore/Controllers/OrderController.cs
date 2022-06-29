
using AnyBuyStore.Core.Handlers.OrderHandler.Commands.DeleteOrder;
using AnyBuyStore.Core.Handlers.OrderHandler.Queries.GetAllByUserId;
using AnyBuyStore.Core.Handlers.OrderHandler.Queries.GetAllOrders;
using AnyBuyStore.Core.Handlers.ProductCategoryHandler.Commands.UpdateProducCategory;
using AnyBuyStore.Core.Handlers.ProductHandler.Commands.CreateProduct;
using AnyBuyStore.Core.Handlers.ProductHandler.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace AnyBuyStore.Controllers
{

    public class OrderController : BaseApiController
    {
        public OrderController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllOrdersQuery(), cancellationToken));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetOrderByIdQuery { Id = Id }, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddOrderCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteOrderCommand { Id = id }, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            command.In.Id = id;
            return Ok(await _mediator.Send(command, cancellationToken));
        }


        [HttpGet]
        public async Task<IActionResult> GetAllByUSerId(int UserId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllByUserIdQuery { UserId = UserId }, cancellationToken));
        }
    }

}