using AnyBuyStore.Core.Handlers.ProductHandler.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnyBuyStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : BaseApiController
    {
        public ProductController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }
        
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllProductsRequest()));
        }

    }

}