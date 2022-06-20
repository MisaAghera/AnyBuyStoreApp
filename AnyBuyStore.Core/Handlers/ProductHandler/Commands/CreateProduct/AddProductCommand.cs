


using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

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
                //UserId = command.In.UserId,
                UserId = 2,
                DiscountId = command.In.DiscountId,
               ProductSubcategoryId = command.In.ProductSubcategoryId,
               Name  = command.In.Name,
               Description = command.In.Description,
               Price = command.In.Price,    
               Brand = command.In.Brand,
                ImageUrl = command.In.ImageUrl,
            Quantity = command.In.Quantity,

            };
            //if (command.In.ProductImg != null)
            //{
            //    string folderPath = "images/";
            //    command.In.ImageUrl = await UploadImages(folderPath, command.In.ProductImg);
            //}

            //addData.ImageUrl = command.In.ImageUrl;

            await _context.AddAsync(addData, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return addData.Id;
        }
        //private async Task<string> UploadImages(string folderPath, IFormFile file)
        //{

        //    folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

        //    var serverFolder = Path.Combine("C:/Users/R9/Desktop/e-Commerce/AnyBuyStore/AnyBuyStore.Core/", folderPath);
        //    //string serverFolder = "C:/Users/R9/Desktop/e-Commerce/AnyBuyStore/AnyBuyStore.Core/" + folderPath;
        //    await file.CopyToAsync(new FileStream(serverFolder,FileMode.Create));
        //    return (folderPath);
        //}
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
        //public IFormFile ProductImg { get; set; }

    }

   

}
