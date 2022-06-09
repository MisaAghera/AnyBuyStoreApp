
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.OrderHandler.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, int>
        {
            private readonly DatabaseContext _context;
            public DeleteOrderHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
            {
                var deleteData = await _context.Order.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (deleteData != null)
                {
                    _context.Order.Remove(deleteData);
                    await _context.SaveChangesAsync();
                    return deleteData.Id;
                }
                return 0;
            }
        }
    }
}

