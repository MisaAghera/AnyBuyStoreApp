
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.OrderDetailsHandler.Commands.DeleteOrderDetailsCommand
{

    public class DeleteOrderDetailsCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductSubcategoryHandler : IRequestHandler<DeleteOrderDetailsCommand, int>
        {
            private readonly DatabaseContext _context;
            public DeleteProductSubcategoryHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteOrderDetailsCommand command, CancellationToken cancellationToken)
            {
                var deleteData = await _context.OrderDetails.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
             
                    _context.OrderDetails.Remove(deleteData);
                    await _context.SaveChangesAsync();
                    return deleteData.Id;
               
            }
        }
    }
}
