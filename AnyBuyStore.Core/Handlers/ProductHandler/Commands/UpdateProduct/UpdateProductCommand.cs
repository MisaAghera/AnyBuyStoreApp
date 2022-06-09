
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
                DiscountId = command.productModel.DiscountId,
                ProductSubcategoryId = command.productModel.ProductSubcategoryId,
                Name = command.productModel.Name,
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
        //var UpdateData = _context.Product.Where(a => a.Id == command.In.Id).FirstOrDefault();
        //if (UpdateData == null)
        //{
        //    return default;
        //}
        //else
        //{
        //    UpdateData.Id = command.In.Id;
        //    UpdateData.DiscountId = command.In.DiscountId;
        //    UpdateData.ProductSubcategoryId = command.In.ProductSubcategoryId;
        //    UpdateData.Name = command.In.Name;
        //    UpdateData.Description = command.In.Description;
        //    UpdateData.Brand = command.In.Brand;
        //    UpdateData.ImageUrl = command.In.ImageUrl;
        //    UpdateData.Quantity = command.In.Quantity;
        //    UpdateData.UpdatedAt = DateTime.Now;

        //    await _context.SaveChangesAsync();
        //    return UpdateData.Id;
        //}
    }
    public class UpdateProductModel
    {
        public int Id { get; set; }
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



