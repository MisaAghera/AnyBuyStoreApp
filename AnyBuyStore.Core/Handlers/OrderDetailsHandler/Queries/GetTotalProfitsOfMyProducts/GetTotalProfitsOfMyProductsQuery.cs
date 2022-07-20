using System;
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetTotalProfitsOfMyProducts
{


    public class GetTotalProfitsOfMyProductsQuery : IRequest<decimal>
    {
        public int UserId { get; set; }

        public class GetTotalProfitsOfMyProductsHandler : IRequestHandler<GetTotalProfitsOfMyProductsQuery, decimal>
        {
            private readonly DatabaseContext _context;
            public GetTotalProfitsOfMyProductsHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<decimal> Handle(GetTotalProfitsOfMyProductsQuery request, CancellationToken cancellationToken)
            {


                var Value = _context.OrderDetails.Join(_context.Product,
                              orderDetail => orderDetail.ProductId,
                              product => product.Id,
                              (orderDetail, product) => new { orderDetail = orderDetail, product = product })
                          .Where(productOrders => productOrders.product.UserId == request.UserId).Sum(ep => ep.orderDetail.Quantity * ep.product.Price);

                
                    return Value;

            }
        }
    }

}


