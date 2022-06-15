


using AnyBuyStore.Data.Data;
using MediatR;
namespace AnyBuyStore.Core.Handlers.ProductHandler.Commands.CreateProduct

{
    public class AddProductCommand : IRequest<int>
    {
        public AddProductCommand(ProductModel @in)
        {
            In = @in;
        }
        public ProductModel In { get; set; }
    }

    public class AddProductHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly DatabaseContext _context;
        public AddProductHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {

            var addData = new Product()
            {
                UserId = command.In.UserId,
               DiscountId = command.In.DiscountId,
               ProductSubcategoryId = command.In.ProductSubcategoryId,
               Name  = command.In.Name,
               Description = command.In.Description,
               Price = command.In.Price,    
               Brand = command.In.Brand,
               ImageUrl = command.In.ImageUrl,
               Quantity = command.In.Quantity,

            };

            await _context.AddAsync(addData, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return addData.Id;
        }
    }
    public class ProductModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? DiscountId { get; set; }
        public int ProductSubcategoryId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; } = String.Empty;
        public string ImageUrl { get; set; } = String.Empty;
        public int Quantity { get; set; } = 1;

    }

}
