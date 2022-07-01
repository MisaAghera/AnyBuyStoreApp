using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnyBuyStore.Core.Handlers.ProductHandler.Commands.CreateProduct

{
    public class AddProductCommand : IRequest<int>
    {

        public ProductModel ProductModel { get; set; }

    }

    public class AddProductHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly DatabaseContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IHttpContextAccessor _contextAccessor;
        public AddProductHandler(IHttpContextAccessor contextAccessor, DatabaseContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _contextAccessor = contextAccessor;
        }

        public async Task<int> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {

            int ProductId = await AddProductDetails( command, cancellationToken);

            var folderName = Path.Combine("Resources", "ProfilePics");
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            var uniqueFileName = $"{command.ProductModel.UserId}_{command.ProductModel.Name}_{ProductId}.png";
            var dbPath = Path.Combine(folderName, uniqueFileName);
            using (var fileStream = new FileStream(Path.Combine(filePath, uniqueFileName), FileMode.Create))
            {
                await command.ProductModel.ProductImg.CopyToAsync(fileStream);
            }

            var UpdateData = _context.Product.Where(a => a.Id == ProductId).FirstOrDefault();
            UpdateData.ImageUrl = dbPath;
            await _context.SaveChangesAsync();
            return ProductId;

        }


        public async Task<int> AddProductDetails(AddProductCommand command, CancellationToken cancellationToken)
        {
            var addData = new Product()
            {
                UserId = command.ProductModel.UserId,
                DiscountId = command.ProductModel.DiscountId,
                ProductSubcategoryId = command.ProductModel.ProductSubcategoryId,
                Name = command.ProductModel.Name,
                Description = command.ProductModel.Description,
                Price = command.ProductModel.Price,
                Brand = command.ProductModel.Brand,
                Quantity = command.ProductModel.Quantity,
            };

            await _context.AddAsync(addData, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return addData.Id;

        }

    }

    public class ProductModel
    {
        //public int Id { get; set; }
        public int UserId { get; set; }
        public int? DiscountId { get; set; }
        public int ProductSubcategoryId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; } = String.Empty;
        public string? ImageUrl { get; set; } = String.Empty;
        public int Quantity { get; set; } = 1;

        public IFormFile ProductImg { get; set; }

    }



}
