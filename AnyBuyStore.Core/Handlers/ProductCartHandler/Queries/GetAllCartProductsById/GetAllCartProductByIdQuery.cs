

using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductCartHandler.Queries.GetAllCartProductsById
{
    public class GetAllCartProductByIdQuery : IRequest<IEnumerable<ProductCartModel>>
    {
        public int UserId { get; set; }

        public class GetAllCartProductByIdHandler : IRequestHandler<GetAllCartProductByIdQuery, IEnumerable<ProductCartModel>>
        {
            private readonly DatabaseContext _context;
            public GetAllCartProductByIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<ProductCartModel>> Handle(GetAllCartProductByIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.ProductCart.Where(a => a.UserId == request.UserId).ToListAsync();

                var getData = new List<ProductCartModel>();

                {
                   
                        foreach (var vals in data)
                        {
                            getData.Add(new ProductCartModel()
                            {
                                UserId = vals.UserId,
                                ProductId = vals.ProductId,
                                Quantity = vals.Quantity,
                                IsAvailable = vals.IsAvailable,
                            });
                        }
                    
                }

                return getData;
            }
        }
    }
    public class ProductCartModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual int ProductId { get; set; }

        public int Quantity { get; set; }

        public bool IsAvailable { get; set; }

    }

}




