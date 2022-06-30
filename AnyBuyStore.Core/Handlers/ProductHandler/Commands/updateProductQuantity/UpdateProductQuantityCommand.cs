using AnyBuyStore.Data.Data;
using MediatR;

namespace AnyBuyStore.Core.Handlers.ProductHandler.updateProductQuantity
{
    public class UpdateProductQuantityCommand : IRequest<bool>
    {
        public UpdateProductQuantityCommand(UpdateProductQuantityModel @in)
        {
            In = @in;
        }
        public UpdateProductQuantityModel In { get; set; }
    }
    public class UpdateProductQuantityHandler : IRequestHandler<UpdateProductQuantityCommand, bool>
    {
        private readonly DatabaseContext _context = null;
        public UpdateProductQuantityHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateProductQuantityCommand command, CancellationToken cancellationToken)
        {
            var UpdateData = _context.Product.Where(a => a.Id == command.In.Id).FirstOrDefault();

            UpdateData.Quantity = command.In.Quantity;

            await _context.SaveChangesAsync();
            return true;

        }
    }
    public class UpdateProductQuantityModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; } = 1;

    }
}

