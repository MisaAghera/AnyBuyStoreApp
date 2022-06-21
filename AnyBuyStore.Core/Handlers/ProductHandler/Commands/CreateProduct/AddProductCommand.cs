


using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

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
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IHttpContextAccessor _contextAccessor;
        public AddProductHandler(IHttpContextAccessor contextAccessor,DatabaseContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _contextAccessor = contextAccessor;
        }

        public async Task<int> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {

            var addData = new Product()
            {
                //UserId = command.In.UserId,
                UserId = 2,
                DiscountId = command.In.DiscountId,
                ProductSubcategoryId = command.In.ProductSubcategoryId,
                Name = command.In.Name,
                Description = command.In.Description,
                Price = command.In.Price,
                Brand = command.In.Brand,
                ImageUrl = command.In.ImageUrl,
                Quantity = command.In.Quantity,

        };

            if (command.In.ProductImg != null)
            {
                
                command.In.ImageUrl = await UploadProfilePicture(command.In.ProductImg);
            }

            //addData.ImageUrl = command.In.ImageUrl;

            await _context.AddAsync(addData, cancellationToken).ConfigureAwait(false);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                return addData.Id;
            }
       
        public async Task<string> UploadProfilePicture(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new("Please select profile picture");

            var folderName = Path.Combine("Resources", "ProfilePics");
          //  var folderName = Path.Combine(_webHostEnvironment.WebRootPath, "images");

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            //var uniqueFileName = $"{userId}_profilepic.png";
            var uniqueFileName = $"{file.FileName}.png";

            var dbPath = Path.Combine(folderName, uniqueFileName);

            using (var fileStream = new FileStream(Path.Combine(filePath, uniqueFileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return dbPath;
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
            public IFormFile ProductImg { get; set; }

        }


    
}
