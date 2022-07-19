using AnyBuyStore.Core.Handlers.AddressHandler.Commands.AddCountry;
using AnyBuyStore.Core.Handlers.AddressHandler.Commands.DeleteCountry;
using AnyBuyStore.Core.Handlers.AddressHandler.Commands.UpdateCountry;
using AnyBuyStore.Core.Handlers.AddressHandler.Queries.GetCountries;
using AnyBuyStore.Core.Handlers.CountryHandler.Queries.GetById;
using API.Errors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnyBuyStore.Controllers
{
    public class CountryController : BaseApiController
    {
        public CountryController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddCountry(AddCountryCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteCountryCommand { Id = id }, cancellationToken));
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountry(int id, UpdateCountryCommand command, CancellationToken cancellationToken)
        {
            command.In.Id = id;
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCountries(CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new GetCountriesQuery(), cancellationToken);
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
