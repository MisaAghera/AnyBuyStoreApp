using AnyBuyStore.Data.Data;
using MediatR;

namespace AnyBuyStore.Core.Handlers.ProductCartHandler.Commands.UpdateProductQuantityInCart

{
    public class UpdateProductQuantityInCartCommand : IRequest<int>
    {
        public UpdateProductQuantityInCartCommand(UpdateProductCartModel @in)
        {
            In = @in;

        }
        public UpdateProductCartModel In { get; set; }
    }

    public class UpdateProductCategoryHandler : IRequestHandler<UpdateProductQuantityInCartCommand, int>
    {
        private readonly DatabaseContext _context;
        public UpdateProductCategoryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateProductQuantityInCartCommand command, CancellationToken cancellationToken)
        {
            var UpdateData = _context.ProductCart.Where(a => a.Id == command.In.Id).FirstOrDefault();
          
                UpdateData.Id = command.In.Id;
                UpdateData.UserId = command.In.UserId;
                UpdateData.ProductId = command.In.ProductId;
                UpdateData.Quantity = command.In.Quantity;
                UpdateData.IsAvailable = command.In.IsAvailable;
                UpdateData.UpdatedAt = DateTime.Now;


                await _context.SaveChangesAsync();
                return UpdateData.Id;
            
        }
    }

    public class UpdateProductCartModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual int ProductId { get; set; }

        public int Quantity { get; set; }

        public bool IsAvailable { get; set; }

    }

}

