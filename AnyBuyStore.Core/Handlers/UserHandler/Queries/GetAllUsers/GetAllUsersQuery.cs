
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.UserHandler.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserModel>> { }

    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserModel>>
    {
        private readonly DatabaseContext _context;
        public GetAllUsersHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.User.ToListAsync();

            var users = new List<UserModel>();

            {
                if (data.Any() == true)
                {
                    foreach (var user in data)
                    {
                        users.Add(new UserModel()
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Email = user.Email,
                            Age = user.Age,
                            Gender = user.Gender,
                            Role = user.Role,
                        });
                    }
                }
            }
            return users;
        }
    }
    public class UserModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int Age { get; set; }

        public string? Gender { get; set; }

        public string Role { get; set; } = string.Empty;
    }

}