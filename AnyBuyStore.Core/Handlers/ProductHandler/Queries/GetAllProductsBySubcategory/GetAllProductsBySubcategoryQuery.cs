using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductHandler.Queries.GetAllProductsBySubcategory
{
    public class GetAllProductsBySubcategoryQuery : IRequest<IEnumerable<ProductModel>>
    {
        public int ProductCategoryId { get; set; }

        public class GetAllProductsBySubcategoryHandler : IRequestHandler<GetAllProductsBySubcategoryQuery, IEnumerable<ProductModel>>
        {
            private readonly DatabaseContext _context;
            public GetAllProductsBySubcategoryHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<ProductModel>> Handle(GetAllProductsBySubcategoryQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.Product.Where(a => a.ProductSubcategoryId == request.ProductCategoryId).Include(a => a.Discount).ToListAsync();

                var getData = new List<ProductModel>();

                {

                    foreach (var product in data)
                    {
                        getData.Add(new ProductModel()
                        {
                            Id = product.Id,
                            UserId = product.UserId,
                            DiscountId = product.DiscountId,
                            ProductSubcategoryId = product.ProductSubcategoryId,
                            Name = product.Name,
                            Description = product.Description,
                            Price = product.Price,
                            Brand = product.Brand,
                            ImageUrl = product.ImageUrl,
                            Quantity = product.Quantity,
                            DiscountValue = product.Discount.Value,

                        });
                    }

                }

                return getData;
            }
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
        public float? DiscountValue { get; set; }


    }

}




