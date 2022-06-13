
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.DiscountHandler.DeleteDiscount
{
    public class DeleteDiscountCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteDiscountHandler : IRequestHandler<DeleteDiscountCommand, int>
        {
            private readonly DatabaseContext _context;
            public DeleteDiscountHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteDiscountCommand command, CancellationToken cancellationToken)
            {
                var deleteData = await _context.Discount.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
            
                    _context.Discount.Remove(deleteData);
                    await _context.SaveChangesAsync();
                    return deleteData.Id;
              
            }
        }
    }
}
