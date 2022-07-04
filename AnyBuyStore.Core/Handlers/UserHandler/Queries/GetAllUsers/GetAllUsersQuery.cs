
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

            var data = await _context.Users.ToListAsync();


            var users = new List<UserModel>();

            {
                
                    foreach (var user in data)
                    {
                        users.Add(new UserModel()
                        {
                            Id = user.Id,
                            UserName = user.UserName,
                            Email = user.Email,
                            Age = user.Age,
                            Gender = user.Gender,
                            PhoneNumber = user.PhoneNumber,
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