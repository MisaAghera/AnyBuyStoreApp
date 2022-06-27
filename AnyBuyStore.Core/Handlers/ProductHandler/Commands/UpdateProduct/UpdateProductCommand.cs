
using AnyBuyStore.Data.Data;
using MediatR;

namespace AnyBuyStore.Core.Handlers.ProductHandler.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public UpdateProductCommand(UpdateProductModel @in)
        {
            In = @in;

        }
        public UpdateProductModel In { get; set; }
    }
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly DatabaseContext _context = null;
        public UpdateProductHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var UpdateData = _context.Product.Where(a => a.Id == command.In.Id).FirstOrDefault();

            UpdateData.UserId = command.In.UserId;
            UpdateData.DiscountId = command.In.DiscountId;
            UpdateData.ProductSubcategoryId = command.In.ProductSubcategoryId;
            UpdateData.Name = command.In.Name;
            UpdateData.Price = command.In.Price;
            UpdateData.Description = command.In.Description;
            UpdateData.Brand = command.In.Brand;
            UpdateData.ImageUrl = command.In.ImageUrl;
            UpdateData.Quantity = command.In.Quantity;
            UpdateData.UpdatedAt = DateTime.Now;


            await _context.SaveChangesAsync();
            return true;

        }
    }
    public class UpdateProductModel
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



