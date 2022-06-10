using AnyBuyStore.Data.Data;
using MediatR;

namespace AnyBuyStore.Core.Handlers.UserHandler.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<int>
    {
        public UpdateUserCommand(UpdateUserModel @in)
        {
            In = @in;

        }
        public UpdateUserModel In { get; set; }
    }

    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly DatabaseContext _context;
        public UpdateUserHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var UpdateData = _context.Users.Where(a => a.Id == command.In.Id).FirstOrDefault();
            if (UpdateData == null)
            {
                return default;
            }
            else
            {
                UpdateData.Id = command.In.Id;
                UpdateData.UserName = command.In.UserName;
                UpdateData.Email = command.In.Email;
                UpdateData.Age = command.In.Age;
                UpdateData.Gender = command.In.Gender;


                await _context.SaveChangesAsync();
                return UpdateData.Id;
            }
        }
    }
    public class UpdateUserModel
    {

        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int? Age { get; set; }

        public string? Gender { get; set; }

    }
}

