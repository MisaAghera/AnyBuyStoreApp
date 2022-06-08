using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static AnyBuyStore.Core.Handlers.ProductCategoryHandler.Queries.GetAllProductCategories.GetAllProductsHandler;

namespace AnyBuyStore.Core.Handlers.ProductCategoryHandler.Queries.GetAllProductCategories
{
   
    public class GetAllProductCetgoriesRequest : IRequest<IEnumerable<ProductCategoryModel>> { }

    public class GetAllProductsHandler : IRequestHandler<GetAllProductCetgoriesRequest, IEnumerable<ProductCategoryModel>>
    {
        private readonly DatabaseContext _context;
        public GetAllProductsHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductCategoryModel>> Handle(GetAllProductCetgoriesRequest request, CancellationToken cancellationToken)
        {
            var data = await _context.ProductCategory.ToListAsync();

            var Products = new List<ProductCategoryModel>();

            {
                if (data.Any() == true)
                {
                    foreach (var product in data)
                    {
                        Products.Add(new ProductCategoryModel()
                        {
                            Id = product.Id,
                            Name = product.Name
                        });
                    }
                }

            }

            return Products;
        }
        public class ProductCategoryModel
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
        }
    }

}