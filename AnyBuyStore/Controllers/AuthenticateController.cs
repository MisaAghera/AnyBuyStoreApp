using AnyBuyStore.Core.Handlers.LoginHandler.Commands.LoginAdminCommand;
using AnyBuyStore.Core.Handlers.LoginHandler.Commands.LoginSellerCommand;
using AnyBuyStore.Core.Handlers.LoginHandler.Commands.LoginUserCommand;
using AnyBuyStore.Core.Handlers.LoginHandler.Commands.refreshToken;
using AnyBuyStore.Core.Handlers.SignupAdminHandler.Commands.SignupAdmin;
using AnyBuyStore.Core.Handlers.SignupHandler.Commands.changePassword;
using AnyBuyStore.Core.Handlers.SignupHandler.Commands.Signup;
using AnyBuyStore.Core.Handlers.SignupHandler.Commands.SignupSeller;
using API.Errors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnyBuyStore.Controllers
{
    public class AuthenticateController : BaseApiController
    {
        public AuthenticateController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCustomer(SignupCustomerCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }


        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(SignupAdminCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }


        [HttpPost]
        public async Task<IActionResult> RegisterSeller(SignupSellerCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> LoginAdmin(LoginAdminCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            if (result == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Refresh(RefreshTokenCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            if (result == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> LoginSeller(LoginSellerCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            if (result == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            if (result == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(result);
        }

    }
}
