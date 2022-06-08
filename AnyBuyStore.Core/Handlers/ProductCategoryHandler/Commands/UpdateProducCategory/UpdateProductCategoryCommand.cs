using AnyBuyStore.Data.Data;
using MediatR;

namespace AnyBuyStore.Core.Handlers.ProductCategoryHandler.Commands.UpdateProducCategory
{
    public class UpdateProductCategoryCommand : IRequest<int>
    {
        public UpdateProductCategoryCommand(UpdateProductCategoryModel @in)
        {
            In = @in;

        }
        public UpdateProductCategoryModel In { get; set; }
    }

    public class UpdateProductCategoryHandler : IRequestHandler<UpdateProductCategoryCommand, int>
    {
        private readonly DatabaseContext _context;
        public UpdateProductCategoryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateProductCategoryCommand command, CancellationToken cancellationToken)
        {
            var UpdateData = _context.ProductCategory.Where(a => a.Id == command.In.Id).FirstOrDefault();
            if (UpdateData == null)
            {
                return default;
            }
            else
            {
                UpdateData.Name = command.In.Name;
                UpdateData.UpdatedAt = DateTime.Now;


                await _context.SaveChangesAsync();
                return UpdateData.Id;
            }
        }
    }
    public class UpdateProductCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

    }

}

