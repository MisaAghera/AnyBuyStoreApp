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
            var UpdateData = _context.User.Where(a => a.Id == command.In.Id).FirstOrDefault();
            if (UpdateData == null)
            {
                return default;
            }
            else
            {
                UpdateData.Id = command.In.Id;
                UpdateData.Name = command.In.Name;
                UpdateData.Email = command.In.Email;
                UpdateData.Age = command.In.Age;
                UpdateData.Gender = command.In.Gender;
                UpdateData.Role = command.In.Role;
                UpdateData.UpdatedAt = DateTime.Now;


                await _context.SaveChangesAsync();
                return UpdateData.Id;
            }
        }
    }
    public class UpdateUserModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string Role { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}

