
using AnyBuyStore.Data.Data;
using MediatR;
namespace AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Commands.AddProductSubCategory
{
    public class AddProductSubcategoryCommand : IRequest<int>
    {
        public AddProductSubcategoryCommand(ProductSubcategoryModel @in)
        {
            In = @in;
        }
        public ProductSubcategoryModel In { get; set; }
    }

    public class AddProductSubcategoryHandler : IRequestHandler<AddProductSubcategoryCommand, int>
    {
        private readonly DatabaseContext _context;
        public AddProductSubcategoryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddProductSubcategoryCommand command, CancellationToken cancellationToken)
        {

            var addData = new ProductSubcategory()
            {
                Name = command.In.Name,
                ProductCategoryId = command.In.ProductCategoryId,

            };

            await _context.AddAsync(addData, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return addData.Id;
        }
    }
    public class ProductSubcategoryModel
    {
        public int Id { get; set; }
        public virtual int ProductCategoryId { get; set; }
        public string Name { get; set; } = String.Empty;

    }

}
