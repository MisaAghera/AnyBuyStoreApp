
using AnyBuyStore.Core.Handlers.OrderDetailsHandler.Commands.AddOrderDetails;
using AnyBuyStore.Core.Handlers.OrderDetailsHandler.Commands.DeleteOrderDetailsCommand;
using AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetAllOrderDetails;
using AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetAllOrderDetailsByOrderId;
using AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetAllOrderDetailsOfMyProducts;
using AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetAllOrderDetailsOfMyProductsByMonth;
using AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetAllOrderDetailsOfMyProductsByYear;
using AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetOrderDetailsById;
using AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetOrderDetailsByOrderDetailsId;
using AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetOrderDetailsByProductId;
using AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetTotalProfitByProductId;
using AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetTotalProfitOfMyProductsOfThisMonth;
using AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetTotalProfitOfMyProductsOfThisYear;
using AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetTotalProfitsOfMyProducts;
using AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Commands.UpdateProductSubCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace AnyBuyStore.Controllers
{

    public class OrderDetailsController : BaseApiController
    {
        public OrderDetailsController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllOrderDetailsQuery(), cancellationToken));
        }

        [Authorize]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetOrderDetailsByIdQuery { Id = Id }, cancellationToken));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddOrderDetailsCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteOrderDetailsCommand { Id = id }, cancellationToken));
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateOrderDetailsCommand command, CancellationToken cancellationToken)
        {
            command.In.Id = id;
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllByOrderId(int OrderId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllOrderDetailsByOrderIdQuery { OrderId = OrderId }, cancellationToken));
        }

        [Authorize]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByOrderDetailId(int Id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetOrderDetailsByOrderDetailsIdQuery { Id = Id }, cancellationToken);
            if (result != null)
            {
                return Ok(result);

            }
            return BadRequest();
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllByProductId(int productId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetOrderDetailByProductIdQuery { productId = productId }, cancellationToken));
        }




        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetailsOfMyProducts(int UserId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllOrderDetailsOfMyProductsQuery { UserId = UserId }, cancellationToken));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetailsOfMyProductsByMonth(int UserId,int month, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllOrderDetailsOfMyProductsByMonthQuery { UserId = UserId , OrderMonth =month}, cancellationToken));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllOrderDetailsOfMyProductsByYea(int UserId, int year, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllOrderDetailsOfMyProductsByYear { UserId = UserId, OrderYear = year }, cancellationToken));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetTotalProfitByProductId(int UserId, int ProductId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetTotalProfitByProductIdQuery { UserId = UserId, ProductId = ProductId }, cancellationToken));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetTotalProfitOfMyProductsOfThisMonth(int UserId, int month, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetTotalProfitOfMyProductsOfThisMonthQuery { UserId = UserId, OrderMonth = month }, cancellationToken));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GeGetTotalProfitOfMyProductsOfThisYear(int UserId, int year, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GeGetTotalProfitOfMyProductsOfThisYearQuery { UserId = UserId, OrderYear = year }, cancellationToken));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetTotalProfitsOfMyProducts(int UserId ,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetTotalProfitsOfMyProductsQuery { UserId = UserId }, cancellationToken));
        }
    }
    
}