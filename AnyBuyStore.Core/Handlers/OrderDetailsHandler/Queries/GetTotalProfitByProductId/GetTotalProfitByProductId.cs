using System;
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetTotalProfitByProductId
{


    public class GetTotalProfitByProductIdQuery : IRequest<decimal>
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public class GetTotalProfitByProductIdHandler : IRequestHandler<GetTotalProfitByProductIdQuery, decimal>
        {
            private readonly DatabaseContext _context;
            public GetTotalProfitByProductIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<decimal> Handle(GetTotalProfitByProductIdQuery request, CancellationToken cancellationToken)
            {


                var Value = _context.OrderDetails.Join(_context.Product,
                              orderDetail => orderDetail.ProductId,
                              product => product.Id,
                              (orderDetail, product) => new { orderDetail = orderDetail, product = product })
                          .Where(productOrders => productOrders.product.UserId == request.UserId && productOrders.orderDetail.ProductId == request.ProductId).Sum(ep => ep.orderDetail.Quantity * ep.product.Price);


                if (Value!=null)
                {
                    return Value;

                }
                else
                    return 0;
            }
        }
    }
 
}



