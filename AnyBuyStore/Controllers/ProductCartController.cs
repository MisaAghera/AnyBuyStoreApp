using AnyBuyStore.Core.Handlers.ProductCartHandler.Commands.AddProductToCart;
using AnyBuyStore.Core.Handlers.ProductCartHandler.Commands.DeleteProductFromCart;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnyBuyStore.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductCartController : BaseApiController
    {
        public ProductCartController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll(int CategoryId)
        //{
        //    return Ok(await _mediator.Send(new GetAllProductSubcategoriesQuery { ProductCategoryId = CategoryId }));
        //}

        //[HttpPost]
        //public async Task<IActionResult> Add(AddProductToCartCommand command)
        //{
        //    return Ok(await _mediator.Send(command));
        //}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return Ok(await _mediator.Send(new DeleteProductFromCartCommand { Id = id }));
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, UpdateProductQuantityInCartCommands command)
        //{
        //    command.In.Id = id;
        //    return Ok(await _mediator.Send(command));
        //}

    }

}


