using AnyBuyStore.Data.Data;
using MediatR;

namespace AnyBuyStore.Core.Handlers.ProductCategoryHandler.Commands.AddProductCategory
{
    public class AddProductCategoryCommand : IRequest<int>
    {
        public AddProductCategoryCommand(ProductCategoryModel @in)
        {
            In = @in;
        }
        public ProductCategoryModel In { get; set; }
    }
    public class AddProductCategoryHandler : IRequestHandler<AddProductCategoryCommand,int>
    {
        private readonly DatabaseContext _context;
        public AddProductCategoryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddProductCategoryCommand command, CancellationToken cancellationToken)
        {
            var addData = new ProductCategory()
            {
                Name = command.In.Name,
                IsActive = true
            };        
            await _context.AddAsync(addData, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return addData.Id;
        }
    }
    public class ProductCategoryModel
    {
        public string Name { get; set; } = string.Empty;    
        public bool IsActive { get; set; }
    }
}
