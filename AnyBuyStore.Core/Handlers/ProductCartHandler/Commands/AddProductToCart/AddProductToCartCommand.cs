using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductCartHandler.Commands.AddProductToCart
{
    public class AddProductToCartCommand : IRequest<int>
    {
        public AddProductToCartCommand(ProductCartModel @in)
        {
            In = @in;
        }
        public ProductCartModel In { get; set; }
    }

    public class AddProductCartHandler : IRequestHandler<AddProductToCartCommand, int>
    {
        private readonly DatabaseContext _context;
        public AddProductCartHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddProductToCartCommand command, CancellationToken cancellationToken)
        {
            var data = await _context.ProductCart.Where(a => a.ProductId == command.In.ProductId).FirstOrDefaultAsync();
            if (data == null)
            {

                var addData = new ProductCart()
                {
                    UserId = command.In.UserId,
                    ProductId = command.In.ProductId,
                    Quantity = command.In.Quantity,
                    IsAvailable = command.In.IsAvailable,
                };

                await _context.AddAsync(addData, cancellationToken).ConfigureAwait(false);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                return addData.Id;
            }
            else
            {
                data.UserId = command.In.UserId;
                data.Quantity += command.In.Quantity;
                data.IsAvailable = command.In.IsAvailable;
                data.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();
                return data.Id;
            }
        }
    }
    public class ProductCartModel
    {
        public int Id { get; set; }

        public  int UserId { get; set; }

        public virtual int ProductId { get; set; }

        public int Quantity { get; set; }

        public bool IsAvailable { get; set; }

    }

}
