using AnyBuyStore.Data.Data;
using AnyBuyStore.Data.Models;
using API.Errors;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AnyBuyStore.Core.Handlers.SignupHandler.Commands.AddRoles
{
    public class AddRoleCommand : IRequest<string>
    {
        public AddRoleCommand(AddExtraRoleModel @in)
        {
            In = @in;
        }
        public AddExtraRoleModel In { get; set; }
    }

    public class AddRoleHandler : IRequestHandler<AddRoleCommand, string>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public AddRoleHandler(DatabaseContext context, UserManager<User> userManager,
           RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<string> Handle(AddRoleCommand command, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByNameAsync(command.In.UserName);
            var success = false;
            if (user == null)
            {
                return null;
            }
            switch (command.In.Role)
            {
                case "Admin":
                    {

                        if (await  _roleManager.RoleExistsAsync(UserRoles.Admin) )
                        {
                            await _userManager.AddToRoleAsync(user, UserRoles.Admin);
                            success = true;
                        }
                    }
                    break;
                case "Customer":
                    {
                        if (await _roleManager.RoleExistsAsync(UserRoles.Customer))
                        {
                            await _userManager.AddToRoleAsync(user, UserRoles.Customer);
                            success = true;

                        }

                    }
                    break;
                case "Seller":
                    {
                        if (await _roleManager.RoleExistsAsync(UserRoles.Seller))
                        {
                            await _userManager.AddToRoleAsync(user, UserRoles.Seller);
                            success = true;

                        }
                    }
                    break;
            }
            if (success == true)
                return command.In.Role;
           
            return null;
           
        }
    }

    public class AddExtraRoleModel
    {
      
        public string Role { get; set; }

        public string UserName { get; set; }
    }
}
