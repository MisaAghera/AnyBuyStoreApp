using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Queries.GetSubcategoryById
{
    public class GetSubcategoryByIdQuery : IRequest<ProductSubcategoryModel>
    {
        public int Id { get; set; }


        public class GetSubcategoryByIdHandler : IRequestHandler<GetSubcategoryByIdQuery, ProductSubcategoryModel>
        {
            private readonly DatabaseContext _context;
            public GetSubcategoryByIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<ProductSubcategoryModel> Handle(GetSubcategoryByIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.ProductSubcategory.Where(a => a.Id == request.Id).Include(a=>a.ProductCategory).FirstOrDefaultAsync();
                if (data != null)
                {
                    var product = new ProductSubcategoryModel()
                    {
                        Id = data.Id,
                        ProductCategoryId = data.ProductCategoryId,
                        CategoryName = data.ProductCategory.Name,
                        Name = data.Name
                    };
                    return product;
                }
                return null;
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


