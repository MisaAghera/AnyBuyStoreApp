using AnyBuyStore.Core.Handlers.AddressHandler.Commands.AddCity;
using AnyBuyStore.Core.Handlers.AddressHandler.Commands.DeleteCity;
using AnyBuyStore.Core.Handlers.AddressHandler.Commands.UpdateCity;
using AnyBuyStore.Core.Handlers.AddressHandler.Queries.GetCities;
using AnyBuyStore.Core.Handlers.AddressHandler.Queries.GetCitiesFromStateId;
using AnyBuyStore.Core.Handlers.CityHandler.Queries.GetById;
using API.Errors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnyBuyStore.Controllers
{
    public class CityController : BaseApiController
    {
        public CityController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddCity(AddCityCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteCityCommand { Id = id }, cancellationToken));
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(int id, UpdateCityCommand command, CancellationToken cancellationToken)
        {
            command.In.Id = id;
            return Ok(await _mediator.Send(command, cancellationToken));
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCities(CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new GetCitiesQuery(), cancellationToken);
            if (result == null) return NotFound(new ApiResponse(404));
            return Ok(result);
        }
        [Authorize]
        [HttpGet("{StateId}")]
        public async Task<IActionResult> GetCitiesFromStateId(int StateId, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new GetCitiesFromStateIdQuery() { StateId = StateId }, cancellationToken);
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
