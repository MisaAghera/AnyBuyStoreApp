using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.AddressHandler.Commands.DeleteState
{
    public class DeleteStateCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteStateHandler : IRequestHandler<DeleteStateCommand, int>
        {
            private readonly DatabaseContext _context;
            public DeleteStateHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteStateCommand command, CancellationToken cancellationToken)
            {
                var deleteData = await _context.States.Where(a => a.Id == command.Id).FirstOrDefaultAsync();

                _context.States.Remove(deleteData);
                await _context.SaveChangesAsync();
                return deleteData.Id;

            }
        }
    }
}
