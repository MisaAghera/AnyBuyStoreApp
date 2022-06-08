using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductCartHandler.Commands.DeleteProductFromCart
{
    public class DeleteProductFromCartCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductFromCartHandler : IRequestHandler<DeleteProductFromCartCommand, int>
        {
            private readonly DatabaseContext _context;
            public DeleteProductFromCartHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteProductFromCartCommand command, CancellationToken cancellationToken)
            {
                var deleteData = await _context.ProductCart.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (deleteData != null)
                {
                    _context.ProductCart.Remove(deleteData);
                    await _context.SaveChangesAsync();
                    return deleteData.Id;
                }
                return 0;
            }
        }
    }
}
