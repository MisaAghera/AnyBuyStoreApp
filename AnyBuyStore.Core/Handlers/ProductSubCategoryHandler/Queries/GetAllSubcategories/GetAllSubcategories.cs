using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductCategoryHandler.Queries.GetAllProductCategories
{

    public class GetAllSubcategories : IRequest<IEnumerable<ProductSubcategoryModel>> { }

    public class GetAllSubcategoriesHandler : IRequestHandler<GetAllSubcategories, IEnumerable<ProductSubcategoryModel>>
    {
        private readonly DatabaseContext _context;
        public GetAllSubcategoriesHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductSubcategoryModel>> Handle(GetAllSubcategories request, CancellationToken cancellationToken)
        {
            var data = await _context.ProductSubcategory.Include(a => a.ProductCategory).ToListAsync();

            var Products = new List<ProductSubcategoryModel>();

            {

                foreach (var product in data)
                {
                    Products.Add(new ProductSubcategoryModel()
                    {
                        Id = product.Id,
                        ProductCategoryId = product.ProductCategoryId,
                        CategoryName = product.ProductCategory.Name,
                        Name = product.Name
                    });
                }

            }

            return Products;
        }
     
    }
    public class ProductSubcategoryModel
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }

        public int ProductCategoryId { get; set; }
        public string Name { get; set; } = String.Empty;

    }
}