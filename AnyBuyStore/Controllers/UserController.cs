using AnyBuyStore.Core.Handlers.UserHandler.Commands.AddUser;
using AnyBuyStore.Core.Handlers.UserHandler.Commands.DeleteUser;
using AnyBuyStore.Core.Handlers.UserHandler.Commands.getUserRoles;
using AnyBuyStore.Core.Handlers.UserHandler.Commands.RemoveUserRole;
using AnyBuyStore.Core.Handlers.UserHandler.Commands.UpdateUser;
using AnyBuyStore.Core.Handlers.UserHandler.Queries.GetAllRoles;
using AnyBuyStore.Core.Handlers.UserHandler.Queries.GetAllUserByRoles;
using AnyBuyStore.Core.Handlers.UserHandler.Queries.GetAllUsers;
using AnyBuyStore.Core.Handlers.UserHandler.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnyBuyStore.Controllers
{
    
    public class UserController : BaseApiController
    {
        public UserController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery(), cancellationToken));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddUserCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteUserCommand { Id = id }, cancellationToken));
        }

        [Authorize]

        [HttpDelete]
        public async Task<IActionResult> DeleteRoles(int userId,int roleId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new removeUserRole { UserId = userId, RoleId = roleId }, cancellationToken));
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserCommand command, CancellationToken cancellationToken)
        {
            command.In.Id = id;
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetRolesByUserId(int UserId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new getUserRoleQuery { UserId = UserId }, cancellationToken));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllByUserRolesId([FromQuery] List<int> RoleId, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllUserByRolesQuery { RoleId = RoleId }, cancellationToken));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllRoles( CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllRolesQuery() , cancellationToken));
        }


        [Authorize]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetUserByIdQuery { Id = Id }, cancellationToken);
            if (result != null)
            {
                return Ok(result);

            }
            return BadRequest();
        }

    }

}


