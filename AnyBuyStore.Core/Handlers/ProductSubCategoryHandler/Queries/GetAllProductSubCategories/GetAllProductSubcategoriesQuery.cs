using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Queries.GetAllProductSubCategories
{
    public class GetAllProductSubcategoriesQuery : IRequest<IEnumerable<ProductSubcategoryModel>>
    {
        public int ProductCategoryId { get; set; }

        public class GetAllProductsHandler : IRequestHandler<GetAllProductSubcategoriesQuery, IEnumerable<ProductSubcategoryModel>>
        {
            private readonly DatabaseContext _context;
            public GetAllProductsHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<ProductSubcategoryModel>> Handle(GetAllProductSubcategoriesQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.ProductSubcategory.Where(a => a.ProductCategoryId == request.ProductCategoryId).Include(a => a.ProductCategory).ToListAsync();

                var getData = new List<ProductSubcategoryModel>();

                {

                    foreach (var vals in data)
                    {
                        getData.Add(new ProductSubcategoryModel()
                        {
                            Id = vals.Id,
                            ProductCategoryId = vals.ProductCategoryId,
                            CategoryName = vals.ProductCategory.Name,
                            Name = vals.Name
                        });
                    }

                }

                return getData;
            }
        }
    }
    public class ProductSubcategoryModel
    {
        public int Id { get; set; }
        public  int ProductCategoryId { get; set; }
        public string? CategoryName { get; set; }

        public string Name { get; set; } = String.Empty;

    }

}




