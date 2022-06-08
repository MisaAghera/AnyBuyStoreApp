using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.UserHandler.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, int>
        {
            private readonly DatabaseContext _context;
            public DeleteUserHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
            {
                var deleteData = await _context.User.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (deleteData != null)
                {
                    _context.User.Remove(deleteData);
                    await _context.SaveChangesAsync();
                    return deleteData.Id;
                }
                return 0;
            }
        }
    }
}
