
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductHandler.Queries.GetProductById
{

    public class GetOrderByIdQuery : IRequest<OrderModel>
    {
        public int Id { get; set; }


        public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderModel>
        {
            private readonly DatabaseContext _context;
            public GetOrderByIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<OrderModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
            {
                var vals = await _context.Order.Where(a => a.Id == request.Id).FirstOrDefaultAsync();

               
                    var Product = new OrderModel()
                    {
                        Id = vals.Id,
                        UserId = vals.UserId,
                        TotalAmount = vals.TotalAmount,
                        TotalDiscount = vals.TotalDiscount

                    };
                    return Product;
               
            }
        }
    }
    public class OrderModel
    {

        public int Id { get; set; }

        public int UserId { get; set; }

        public decimal? TotalAmount { get; set; }

        public decimal? TotalDiscount { get; set; }
    }
}


