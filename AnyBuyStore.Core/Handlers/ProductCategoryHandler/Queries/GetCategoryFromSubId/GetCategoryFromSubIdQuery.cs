
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductCategoryHandler.Queries.GetCategoryFromSubId
{
    public class GetCategoryFromSubIdQuery : IRequest<int>
    {
        public int SubcategoryId { get; set; }

        public class GetCategoryFromSubIdHandler: IRequestHandler<GetCategoryFromSubIdQuery,int>
        {
            private readonly DatabaseContext _context;
            public GetCategoryFromSubIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(GetCategoryFromSubIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.ProductSubcategory.Where(a => a.Id == request.SubcategoryId).FirstOrDefaultAsync();

                return data.ProductCategoryId ;
            }
        }
    }
}





