using AnyBuyStore.Data.Data;
using AnyBuyStore.Data.Models;
using API.Errors;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AnyBuyStore.Core.Handlers.SignupHandler.Commands.Signup
{
    public class SignupCustomerCommand : IRequest<IdentityResult>
    {
        public SignupCustomerCommand(RegisterModel @in)
        {
            In = @in;
        }
        public RegisterModel In { get; set; }

    }
    public class RegisterHandler : IRequestHandler<SignupCustomerCommand, IdentityResult>
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public RegisterHandler(DatabaseContext context,UserManager<User> userManager,
           RoleManager<IdentityRole<int>> roleManager)
        {
            _context = context;
            _userManager = userManager;
          _roleManager = roleManager;
        }
        public async Task<IdentityResult> Handle(SignupCustomerCommand command, CancellationToken cancellationToken)
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
                PhoneNumber = command.In.PhoneNumber,
                Gender = command.In.Gender,
                Age = command.In.Age,
            };
            var result = await _userManager.CreateAsync(user, command.In.Password);
            //if (!await _roleManager.RoleExistsAsync(UserRoles.Customer))
            //    await _roleManager.CreateAsync(new IdentityRole<int>(UserRoles.Customer));

            //if (await _roleManager.RoleExistsAsync(UserRoles.Customer))
            //{
            //    await _userManager.AddToRoleAsync(user, UserRoles.Customer);
            //}

            if (!result.Succeeded)
            {
                new ApiResponse(500);

                //return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }
            return result;

        }
    }

    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; } = string.Empty;

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public string? Gender { get; set; }

        public int? Age { get; set; }
    }

    //public class ResponseModel
    //{
    //    public string Status { get; set; }
    //    public string Message { get; set; }

    //}
}
