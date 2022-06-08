using AnyBuyStore.Data.Data;
using MediatR;
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
            var addData = new ProductCart()
            {
                UserId = command.In.UserId,
                ProductId = command.In.ProductId,
                Quantity  = command.In.Quantity,
                Price = command.In.Price,
                IsAvailable = command.In.IsAvailable,
            };

            await _context.AddAsync(addData, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return addData.Id;
        }
    }
    public class ProductCartModel
    {
        public int Id { get; set; }

        public  int UserId { get; set; }

        public virtual int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

    }

}
