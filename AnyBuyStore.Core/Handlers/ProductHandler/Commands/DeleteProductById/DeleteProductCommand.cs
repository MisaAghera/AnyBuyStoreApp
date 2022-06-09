
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductHandler.Commands.DeleteProductById
{
    public class DeleteProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, int>
        {
            private readonly DatabaseContext _context;
            public DeleteProductHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
            {
                var deleteData = await _context.Product.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (deleteData != null)
                {
                    _context.Product.Remove(deleteData);
                    await _context.SaveChangesAsync();
                    return deleteData.Id;
                }
                return 0;
            }
        }
    }
}

