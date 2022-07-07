using System;
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetTotalProfitOfMyProductsOfThisMonth
{


    public class GetTotalProfitOfMyProductsOfThisMonthQuery : IRequest<decimal>
    {
        public int UserId { get; set; }
        public int OrderMonth { get; set; }

        public class GetTotalProfitOfMyProductsOfThisMonthHandler : IRequestHandler<GetTotalProfitOfMyProductsOfThisMonthQuery, decimal>
        {
            private readonly DatabaseContext _context;
            public GetTotalProfitOfMyProductsOfThisMonthHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<decimal> Handle(GetTotalProfitOfMyProductsOfThisMonthQuery request, CancellationToken cancellationToken)
            {


                var Value = _context.OrderDetails.Join(_context.Product,
                              orderDetail => orderDetail.ProductId,
                              product => product.Id,
                              (orderDetail, product) => new { orderDetail = orderDetail, product = product })
                          .Where(productOrders => productOrders.product.UserId == request.UserId && productOrders.orderDetail.UpdatedAt.Month == request.OrderMonth).Sum(ep => ep.orderDetail.Quantity * ep.product.Price);


                if (Value != null)
                {
                    return Value;

                }
                else
                    return 0;
            }
        }
    }
  
}


