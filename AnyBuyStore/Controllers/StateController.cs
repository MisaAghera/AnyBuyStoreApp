using AnyBuyStore.Core.Handlers.AddressHandler.Commands.AddState;
using AnyBuyStore.Core.Handlers.AddressHandler.Commands.DeleteState;
using AnyBuyStore.Core.Handlers.AddressHandler.Commands.UpdateState;
using AnyBuyStore.Core.Handlers.AddressHandler.Queries.GetStates;
using AnyBuyStore.Core.Handlers.AddressHandler.Queries.GetStatesFromCountryId;
using AnyBuyStore.Core.Handlers.StateHandler.Queries.GetById;
using API.Errors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnyBuyStore.Controllers
{
    public class StateController : BaseApiController
    {
        public StateController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddState(AddStateCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteStateCommand { Id = id }, cancellationToken));
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateState(int id, UpdateStateCommand command, CancellationToken cancellationToken)
        {
            command.In.Id = id;
            return Ok(await _mediator.Send(command, cancellationToken));
        }


        [Authorize]
        [HttpGet("{CountryId}")]
        public async Task<IActionResult> GetStatesFromCountryId(int CountryId, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new GetStatesFromCountryIdQuery() { CountryId = CountryId }, cancellationToken);
            if (result == null) return NotFound(new ApiResponse(404));
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetStates(CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new GetStatesQuery(), cancellationToken);
            if (result == null) return NotFound(new ApiResponse(404));
            return Ok(result);
        }


        [Authorize]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new GetByIdQuery() { Id = Id }, cancellationToken);
            if (result == null) return NotFound(new ApiResponse(404));
            return Ok(result);
        }
    }
}
