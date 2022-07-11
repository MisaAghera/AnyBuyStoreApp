using AnyBuyStore.Data.Data;
using AnyBuyStore.Data.Models;
using API.Errors;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AnyBuyStore.Core.Handlers.SignupHandler.Commands.changePassword
{
    public class ChangePasswordCommand : IRequest<IdentityResult>
    {
        public ChangePasswordCommand(PasswordChangeModel @in)
        {
            In = @in;
        }
        public PasswordChangeModel In { get; set; }
    }

    public class RegisterAdminHandler : IRequestHandler<ChangePasswordCommand, IdentityResult>
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public RegisterAdminHandler(DatabaseContext context, UserManager<User> userManager,
           RoleManager<IdentityRole<int>> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
        {

            var userExists = await _userManager.FindByIdAsync(command.In.UserId.ToString());
            if (userExists == null)
            {
                new ApiResponse(500);
            }

            var userId = command.In.UserId;
            var result = await _userManager.ChangePasswordAsync(userExists, command.In.OldPassword, command.In.NewPassword);
            return result;
        }
    }
}

public class PasswordChangeModel
{
    public int? UserId { get; set; }

    public string? OldPassword { get; set; }

    public string? NewPassword { get; set; }
}

   


