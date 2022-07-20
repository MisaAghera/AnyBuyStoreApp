using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AnyBuyStore.Core.Handlers.UserHandler.Queries.GetAllUserByRoles
{
    public class GetAllUserByRolesQuery : IRequest<IEnumerable<UserModel>> {
        public List<int> RoleId { get; set; }
    }

    public class GetAllUsersHandler : IRequestHandler<GetAllUserByRolesQuery, IEnumerable<UserModel>>
    {
        private readonly DatabaseContext _context;
        public GetAllUsersHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserModel>> Handle(GetAllUserByRolesQuery request, CancellationToken cancellationToken)
        {
            
            var data = _context.Users.Join(_context.UserRoles, user => user.Id, userRoles => userRoles.UserId, (user, userRoles) => new { User = user, UserRoles = userRoles }
                ).Where(userandroles => request.RoleId.Contains(userandroles.UserRoles.RoleId)).GroupBy(car => car.User.Id).Select(g => g.First()).ToList();
          

            var users = new List<UserModel>();

            {

                foreach (var user in data)
                {
                    users.Add(new UserModel()
                    {
                        Id = user.User.Id,
                        Role = user.UserRoles.RoleId,
                        UserName = user.User.UserName,
                        Email = user.User.Email,
                        Age = user.User.Age,
                        Gender = user.User.Gender,
                        PhoneNumber = user.User.PhoneNumber,
                    });
                }

            }
            return users;
        }
    }
    public class UserModel
    {
        public int Id { get; set; }
        public int Role { get; set; }
        public string? PhoneNumber { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int? Age { get; set; }

        public string? Gender { get; set; }

    }

}