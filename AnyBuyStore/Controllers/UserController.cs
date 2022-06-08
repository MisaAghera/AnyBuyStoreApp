

using AnyBuyStore.Core.Handlers.UserHandler.Commands.AddUser;
using AnyBuyStore.Core.Handlers.UserHandler.Commands.DeleteUser;
using AnyBuyStore.Core.Handlers.UserHandler.Commands.UpdateUser;
using AnyBuyStore.Core.Handlers.UserHandler.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnyBuyStore.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : BaseApiController
    {
        public UserController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery() ));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteUserCommand { Id = id }));
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, UpdateUserCommand command)
        //{
        //    command.In.Id = id;
        //    return Ok(await _mediator.Send(command));
        //}

    }

}


