using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.UserHandler.Commands.getUserRoles
{
    public class getUserRoleQuery : IRequest<IEnumerable<UserRoleModel>>
    {
        public int UserId { get; set; }
    }

    public class GetAllUsersHandler : IRequestHandler<getUserRoleQuery, IEnumerable<UserRoleModel>>
    {
        private readonly DatabaseContext _context;
        public GetAllUsersHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserRoleModel>> Handle(getUserRoleQuery request, CancellationToken cancellationToken)
        {

            var data = await _context.UserRoles.Join(_context.Roles, userRole => userRole.RoleId, roles => roles.Id, (userRole, roles) => new { UserRole = userRole, Roles = roles }
                ).Where(userAndroles => userAndroles.UserRole.UserId == request.UserId).ToListAsync();


            var users = new List<UserRoleModel>();

            {

                foreach (var user in data)
                {
                    users.Add(new UserRoleModel()
                    {
                        Id = user.Roles.Id,
                        Name = user.Roles.Name,
                    });
                }

            }
            return users;
        }
    }
    public class UserRoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

}