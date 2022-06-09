using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnyBuyStore.Controllers
{
    [ApiController]

    [Route("[controller]/[action]")]

    public abstract class BaseApiController : ControllerBase
    {
        public readonly ILogger<BaseApiController> _logger;
        public readonly IMediator _mediator;

        public BaseApiController(
            ILogger<BaseApiController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
       

    }
}