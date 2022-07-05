using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductCategoryHandler.Queries.GetById
{
    public class GetByIdQuery : IRequest<ProductCategoryModel>
    {
        public int Id { get; set; }


        public class GetProductByIdHandler : IRequestHandler<GetByIdQuery, ProductCategoryModel>
        {
            private readonly DatabaseContext _context;
            public GetProductByIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<ProductCategoryModel> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.ProductCategory.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (data != null)
                {
                    var product = new ProductCategoryModel()
                    {
                        Id = data.Id,
                        Name = data.Name
                    };
                    return product;
                }
                return null;
            }
        }
    }

    public class ProductCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

}


