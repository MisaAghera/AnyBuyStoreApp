
using AnyBuyStore.Data.Data;
using MediatR;

namespace AnyBuyStore.Core.Handlers.ProductHandler.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<bool>
    {
        //public UpdateProductCommand(ProductModel @in)
        //{
        //    In = @in;

        //}
        public UpdateProductModel productModel { get; set; }
        //}
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
            var product = new Product()
            {

                Id = command.productModel.Id,
                UserId = command.productModel.UserId,
                DiscountId = command.productModel.DiscountId,
                ProductSubcategoryId = command.productModel.ProductSubcategoryId,
                Name = command.productModel.Name,
                Price = command.productModel.Price, 
                Description = command.productModel.Description,
                Brand = command.productModel.Brand,
                ImageUrl = command.productModel.ImageUrl,
                Quantity = command.productModel.Quantity,
                UpdatedAt = DateTime.Now
            };

            _context.Product.Update(product);
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



