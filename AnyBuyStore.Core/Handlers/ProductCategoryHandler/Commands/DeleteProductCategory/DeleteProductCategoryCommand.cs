using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductCategoryHandler.Commands.DeleteProductCategory
{
    public class DeleteProductCategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductCategoryHandler : IRequestHandler<DeleteProductCategoryCommand, int>
        {
            private readonly DatabaseContext _context;
            public DeleteProductCategoryHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteProductCategoryCommand command, CancellationToken cancellationToken)
            {
                var deleteData = await _context.ProductCategory.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
          
                    _context.ProductCategory.Remove(deleteData);
                    await _context.SaveChangesAsync();
                    return deleteData.Id;
               
            }
        }
    }
}
