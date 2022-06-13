using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Commands.DeleteProductSubCategory
{
    public class DeleteProductSubcategoryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductSubcategoryHandler : IRequestHandler<DeleteProductSubcategoryCommand, int>
        {
            private readonly DatabaseContext _context;
            public DeleteProductSubcategoryHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteProductSubcategoryCommand command, CancellationToken cancellationToken)
            {
                var deleteData = await _context.ProductSubcategory.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
              
                    _context.ProductSubcategory.Remove(deleteData);
                    await _context.SaveChangesAsync();
                    return deleteData.Id;
           
            }
        }
    }
}
