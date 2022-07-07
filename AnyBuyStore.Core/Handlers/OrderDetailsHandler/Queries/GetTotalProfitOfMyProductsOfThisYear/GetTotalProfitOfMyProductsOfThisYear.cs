using System;
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetTotalProfitOfMyProductsOfThisYear
{


    public class GeGetTotalProfitOfMyProductsOfThisYearQuery : IRequest<decimal>
    {
        public int UserId { get; set; }
        public int OrderYear { get; set; }

        public class GetAllOrderDetailsOfMyProductsByMonthHandler : IRequestHandler<GeGetTotalProfitOfMyProductsOfThisYearQuery, decimal>
        {
            private readonly DatabaseContext _context;
            public GetAllOrderDetailsOfMyProductsByMonthHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<decimal> Handle(GeGetTotalProfitOfMyProductsOfThisYearQuery request, CancellationToken cancellationToken)
            {


                var Value = _context.OrderDetails.Join(_context.Product,
                              orderDetail => orderDetail.ProductId,
                              product => product.Id,
                              (orderDetail, product) => new { orderDetail = orderDetail, product = product })
                          .Where(productOrders => productOrders.product.UserId == request.UserId && productOrders.orderDetail.UpdatedAt.Year == request.OrderYear).Sum(ep => ep.orderDetail.Quantity * ep.product.Price);
                
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


