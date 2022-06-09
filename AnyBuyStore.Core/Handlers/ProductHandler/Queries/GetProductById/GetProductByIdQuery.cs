
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductHandler.Queries.GetProductById
{

    public class GetProductByIdQuery : IRequest<ProductModel>
    {
        public int Id { get; set; }


        public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductModel>
        {
            private readonly DatabaseContext _context;
            public GetProductByIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<ProductModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.Product.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if(data!= null)
                {
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
                return null;
                           
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

}


