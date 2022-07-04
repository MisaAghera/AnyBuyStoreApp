using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.UserHandler.Queries.GetUserById
{

    public class GetUserByIdQuery : IRequest<UserModel>
    {
        public int Id { get; set; }


        public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserModel>
        {
            private readonly DatabaseContext _context;
            public GetUserByIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (user != null)
                {
                    var product = new UserModel()
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        Email = user.Email,
                        Age = user.Age,
                        Gender = user.Gender,
                        PhoneNumber = user.PhoneNumber,
                    };
                    return product;
                }
                return null;
            }
        }
    }
    public class UserModel
    {
        public int Id { get; set; }
        public int Role { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string Email { get; set; } = string.Empty;

        public int? Age { get; set; }

        public string? Gender { get; set; }

    }

}


