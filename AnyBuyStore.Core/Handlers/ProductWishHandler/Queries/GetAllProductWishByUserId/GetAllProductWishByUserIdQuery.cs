
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductWish.Queries.GetAllProductWishById
{
    public class GetAllProductWishByUserIdQuery : IRequest<IEnumerable<ProductWishModel>>
    {
        public int UserId { get; set; }

        public class GetAllProductWishByUserIdHandler : IRequestHandler<GetAllProductWishByUserIdQuery, IEnumerable<ProductWishModel>>
        {
            private readonly DatabaseContext _context;
            public GetAllProductWishByUserIdHandler (DatabaseContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<ProductWishModel>> Handle(GetAllProductWishByUserIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.ProductWish.Where(a => a.UserId == request.UserId).ToListAsync();

                var getData = new List<ProductWishModel>();

                {
                    
                        foreach (var vals in data)
                        {
                            getData.Add(new ProductWishModel()
                            {
                                UserId = vals.UserId,
                                ProductId = vals.ProductId,
                                Id = vals.Id,
                               
                            });
                        }
                    
                }

                return getData;
            }
        }
    }
    public class ProductWishModel
    {
        public int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual int ProductId { get; set; }

    }

}




