using System;
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetAllOrderDetailsOfMyProductsByMonth
{


    public class GetAllOrderDetailsOfMyProductsByMonthQuery : IRequest<IEnumerable<OrderDetailsDetailsModel>>
    {
        public int UserId { get; set; }
        public int OrderMonth { get; set; }

        public class GetAllOrderDetailsOfMyProductsByMonthHandler : IRequestHandler<GetAllOrderDetailsOfMyProductsByMonthQuery, IEnumerable<OrderDetailsDetailsModel>>
        {
            private readonly DatabaseContext _context;
            public GetAllOrderDetailsOfMyProductsByMonthHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<OrderDetailsDetailsModel>> Handle(GetAllOrderDetailsOfMyProductsByMonthQuery request, CancellationToken cancellationToken)
            {


                var Values = _context.OrderDetails.Join(_context.Product,
                              orderDetail => orderDetail.ProductId,
                              product => product.Id,
                              (orderDetail, product) => new { orderDetail = orderDetail, product = product })
                          .Where(productOrders => productOrders.product.UserId == request.UserId && productOrders.orderDetail.UpdatedAt.Month == request.OrderMonth).ToListAsync();



                var getData = new List<OrderDetailsDetailsModel>();

                {

                    foreach (var data in await Values)
                    {
                        getData.Add(new OrderDetailsDetailsModel()
                        {
                            Id = data.orderDetail.Id,
                            ProductId = data.orderDetail.ProductId,
                            OrderId = data.orderDetail.OrderId,
                            DiscountId = data.product.DiscountId,
                            Quantity = data.orderDetail.Quantity,
                            Status = data.orderDetail.Status,
                            UpdatedAt = data.orderDetail.UpdatedAt,
                            Price = data.product.Price,
                            ProductName = data.product.Name,

                        });
                    }

                }

                return getData;
            }
        }
    }
    public class OrderDetailsDetailsModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public int OrderId { get; set; }

        public int? DiscountId { get; set; }

        public int Quantity { get; set; }

        public string Status { get; set; } = string.Empty;

        public decimal Price { get; set; } = 0;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }

}


