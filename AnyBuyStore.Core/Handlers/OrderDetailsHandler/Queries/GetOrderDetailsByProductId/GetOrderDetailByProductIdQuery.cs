using System;
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetOrderDetailsByProductId
{


    public class GetOrderDetailByProductIdQuery : IRequest<IEnumerable<OrderDetailsDetailsModel>>
    {
        public int productId { get; set; }

        public class GetOrderDetailByProductIdHandler : IRequestHandler<GetOrderDetailByProductIdQuery, IEnumerable<OrderDetailsDetailsModel>>
        {
            private readonly DatabaseContext _context;
            public GetOrderDetailByProductIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<OrderDetailsDetailsModel>> Handle(GetOrderDetailByProductIdQuery request, CancellationToken cancellationToken)
            {

                var data = await _context.OrderDetails.Where(a => a.ProductId == request.productId).Include(a => a.Product).ToListAsync();
       

                var getData = new List<OrderDetailsDetailsModel>();

                {

                    foreach (var vals in data)
                    {
                        getData.Add(new OrderDetailsDetailsModel()
                        {
                            Id = vals.Id,
                            ProductId = vals.ProductId,
                            OrderId = vals.OrderId,
                            DiscountId = vals.DiscountId,
                            Quantity = vals.Quantity,
                            Status = vals.Status,
                            UpdatedAt = vals.UpdatedAt,
                            Price = vals.Product.Price,
                            ProductName = vals.Product.Name,

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


