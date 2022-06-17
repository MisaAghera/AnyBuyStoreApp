using AnyBuyStore.Core.Handlers.AddressHandler.Commands.AddAddress;
using AnyBuyStore.Core.Handlers.AddressHandler.Commands.DeleteAddress;
using AnyBuyStore.Core.Handlers.AddressHandler.Commands.UpdateAddress;
using AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Queries.GetAddressByOrderIdQuery;
using API.Errors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace AnyBuyStore.Controllers
{
    //[Authorize]

    public class AddressController : BaseApiController
    {
        public AddressController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new GetAddressByOrderIdQuery() { OrderDetailsId = Id }, cancellationToken);
            if (result == null) return NotFound(new ApiResponse(404));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAddressCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteAddressCommand { Id = id }, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAddressCommand command, CancellationToken cancellationToken)
        {
            command.In.Id = id;
            return Ok(await _mediator.Send(command, cancellationToken));
        }

    }

}