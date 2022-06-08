using AnyBuyStore.Data.Data;
using MediatR;

namespace AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Commands.UpdateProductSubCategory
{
    public class UpdateProductSubcategoryCommand : IRequest<int>
    {
        public UpdateProductSubcategoryCommand(UpdateProductsubcategoryModel @in)
        {
            In = @in;

        }
        public UpdateProductsubcategoryModel In { get; set; }
    }

    public class UpdateProductCategoryHandler : IRequestHandler<UpdateProductSubcategoryCommand, int>
    {
        private readonly DatabaseContext _context;
        public UpdateProductCategoryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateProductSubcategoryCommand command, CancellationToken cancellationToken)
        {
            var UpdateData = _context.ProductSubcategory.Where(a => a.Id == command.In.Id).FirstOrDefault();
            if (UpdateData == null)
            {
                return default;
            }
            else
            {
                UpdateData.Name = command.In.Name;
                UpdateData.ProductCategoryId = command.In.ProductCategoryId;
                UpdateData.UpdatedAt = DateTime.Now;


                await _context.SaveChangesAsync();
                return UpdateData.Id;
            }
        }
    }
    public class UpdateProductsubcategoryModel
    {
        public int Id { get; set; }
        public virtual int ProductCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}

