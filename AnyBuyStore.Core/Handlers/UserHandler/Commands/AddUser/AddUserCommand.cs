using AnyBuyStore.Data.Data;
using MediatR;
namespace AnyBuyStore.Core.Handlers.UserHandler.Commands.AddUser
{
    public class AddUserCommand : IRequest<int>
    {
        public AddUserCommand(UserModel @in)
        {
            In = @in;
        }
        public UserModel In { get; set; }
    }
    public class AddUserHandler : IRequestHandler<AddUserCommand, int>
    {
        private readonly DatabaseContext _context;
        public AddUserHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            var addData = new User()
            {
                Name = command.In.Name,
                Email = command.In.Email,
                Age = command.In.Age,
                Gender = command.In.Gender,
                Role = command.In.Role,
            };
            await _context.AddAsync(addData, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return addData.Id;
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
