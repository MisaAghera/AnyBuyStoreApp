
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AnyBuyStore.Core.Handlers.ProductHandler.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public UpdateProductModel ProductModel { get; set; }

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
            var UpdateData = _context.Product.Where(a => a.Id == command.ProductModel.Id).FirstOrDefault();



            UpdateData.UserId = command.ProductModel.UserId;
            UpdateData.DiscountId = command.ProductModel.DiscountId;
            UpdateData.ProductSubcategoryId =command.ProductModel.ProductSubcategoryId;
            UpdateData.Name = command.ProductModel.Name;
            UpdateData.Price = command.ProductModel.Price;
            UpdateData.Description = command.ProductModel.Description;
            UpdateData.Brand = command.ProductModel.Brand;
            UpdateData.Quantity = command.ProductModel.Quantity;
            UpdateData.UpdatedAt = DateTime.Now;

            var folderName = Path.Combine("Resources", "ProfilePics");
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName);



            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            if (command.ProductModel.ProductImg == null)
            {

            }
            else
            {
                if (System.IO.File.Exists(UpdateData.ImageUrl))
                    System.IO.File.Delete(UpdateData.ImageUrl);


                var uniqueFileName = $"{command.ProductModel.UserId}_{command.ProductModel.Name}_{command.ProductModel.Id}.png";
                var dbPath = Path.Combine(folderName, uniqueFileName);
                using (var fileStream = new FileStream(Path.Combine(filePath, uniqueFileName), FileMode.Create))
                {
                    await command.ProductModel.ProductImg.CopyToAsync(fileStream);
                }

                UpdateData.ImageUrl = dbPath;

            }
            UpdateData.ImageUrl = UpdateData.ImageUrl;


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
        public string? ImageUrl { get; set; } = String.Empty;
        public int Quantity { get; set; } = 1;
        public IFormFile? ProductImg { get; set; }

    }
}



