using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductCartHandler.Commands.DeleteCartFromUserId
{
    public class DeleteCartFromUserIdCommand : IRequest<bool>
    {
        public int userId { get; set; }
        public class DeleteProductFromCartHandler : IRequestHandler<DeleteCartFromUserIdCommand, bool>
        {
            private readonly DatabaseContext _context;
            public DeleteProductFromCartHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<bool> Handle(DeleteCartFromUserIdCommand command, CancellationToken cancellationToken)
            {

                var list = await _context.ProductCart.Where(a => a.UserId == command.userId).ToListAsync();
                _context.ProductCart.RemoveRange(list);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
