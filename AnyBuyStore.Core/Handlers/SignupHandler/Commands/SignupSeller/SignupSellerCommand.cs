using AnyBuyStore.Data.Data;
using AnyBuyStore.Data.Models;
using API.Errors;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AnyBuyStore.Core.Handlers.SignupHandler.Commands.SignupSeller
{
    public class SignupSellerCommand : IRequest<IdentityResult>
    {
        public SignupSellerCommand(RegisterSellerModel @in)
        {
            In = @in;
        }
        public RegisterSellerModel In { get; set; }
    }

    public class RegisterSellerHandler : IRequestHandler<SignupSellerCommand, IdentityResult>
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public RegisterSellerHandler(DatabaseContext context, UserManager<User> userManager,
           RoleManager<IdentityRole<int>> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> Handle(SignupSellerCommand command, CancellationToken cancellationToken)
        {

            var userExists = await _userManager.FindByNameAsync(command.In.Username);
            if (userExists != null)
            {
                new ApiResponse(500);
            }

            User user = new()
            {
                Email = command.In.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = command.In.Username,
            };

            var result = await _userManager.CreateAsync(user, command.In.Password);

            if (!result.Succeeded)
            {
                new ApiResponse(500);
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Admin));

            if (!await _roleManager.RoleExistsAsync(UserRoles.Customer))
                await _roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Customer));

            if (!await _roleManager.RoleExistsAsync(UserRoles.Seller))
                await _roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Seller));


            if (await _roleManager.RoleExistsAsync(UserRoles.Seller))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Customer);
            }

            if (await _roleManager.RoleExistsAsync(UserRoles.Seller))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Seller);
            }
            return result;
        }
    }

    public class RegisterSellerModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
