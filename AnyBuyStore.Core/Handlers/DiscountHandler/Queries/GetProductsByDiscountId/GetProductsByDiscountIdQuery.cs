

using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.DiscountHandler.Queries.GetProductsByDiscountId
{

    public class GetProductsByDiscountIdQuery : IRequest<IEnumerable<ProductModel>>
    {
        public int DiscountId { get; set; }


        public class GetProductsByDiscountIdHandler : IRequestHandler<GetProductsByDiscountIdQuery, IEnumerable<ProductModel>>
        {
            private readonly DatabaseContext _context;
            public GetProductsByDiscountIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<ProductModel>> Handle(GetProductsByDiscountIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.Product.Where(a => a.DiscountId == request.DiscountId).ToListAsync();


                var Products = new List<ProductModel>();


                if (data.Any() == true)
                {
                    foreach (var product in data)
                    {
                        Products.Add(new ProductModel()
                        {
                            Id = product.Id,
                            DiscountId = product.DiscountId,
                            ProductSubcategoryId = product.ProductSubcategoryId,
                            Name = product.Name,
                            Description = product.Description,
                            Price = product.Price,
                            Brand = product.Brand,
                            ImageUrl = product.ImageUrl,
                            Quantity = product.Quantity
                        });
                    }
                }
                return Products;
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

