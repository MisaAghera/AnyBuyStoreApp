using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.UserHandler.Queries.GetAllRoles
{ 
    public class GetAllRolesQuery : IRequest<IEnumerable<UserRoleModel>> { }

    public class GetAllUsersHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<UserRoleModel>>
    {
        private readonly DatabaseContext _context;
        public GetAllUsersHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserRoleModel>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {

            var data = await _context.Roles.ToListAsync();


            var users = new List<UserRoleModel>();

            {

                foreach (var user in data)
                {
                    users.Add(new UserRoleModel()
                    {
                        Id = user.Id,
                        Name = user.Name,
     
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