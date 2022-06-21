using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.EarningHandler.Queries.getMonthlyEarning
{

    public class getMonthlyEarningQuery : IRequest<ProductModel>
    {
        public int Id { get; set; }


        public class getMonthlyEarningHandler : IRequestHandler<getMonthlyEarningQuery, ProductModel>
        {
            private readonly DatabaseContext _context;
            public getMonthlyEarningHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<ProductModel> Handle(getMonthlyEarningQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.Product.Where(a => a.Id == request.Id).FirstOrDefaultAsync();

                var product = new ProductModel()
                {
                    Id = data.Id,
                    DiscountId = data.DiscountId,
                    ProductSubcategoryId = data.ProductSubcategoryId,
                    Name = data.Name,
                    Description = data.Description,
                    Price = data.Price,
                    Brand = data.Brand,
                    ImageUrl = data.ImageUrl,
                    Quantity = data.Quantity
                };
                return product;


            }
        }
    }
    public class ProductModel
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
    public class responseModel
        {
            
        }

}


