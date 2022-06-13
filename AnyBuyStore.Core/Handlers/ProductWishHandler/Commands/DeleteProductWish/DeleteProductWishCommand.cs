using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductWish.Commands.DeleteProductWish
{
    public class DeleteProductWishCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductWishHandler : IRequestHandler<DeleteProductWishCommand, int>
        {
            private readonly DatabaseContext _context;
            public DeleteProductWishHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteProductWishCommand command, CancellationToken cancellationToken)
            {
                var deleteData = await _context.ProductWish.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
          
                    _context.ProductWish.Remove(deleteData);
                    await _context.SaveChangesAsync();
                    return deleteData.Id;
          
            }
        }
    }
}
