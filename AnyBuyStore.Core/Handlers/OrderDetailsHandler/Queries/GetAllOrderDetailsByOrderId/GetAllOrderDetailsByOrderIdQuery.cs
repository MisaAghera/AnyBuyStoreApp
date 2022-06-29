using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetAllOrderDetailsByOrderId
{
    public class GetAllOrderDetailsByOrderIdQuery : IRequest<IEnumerable<OrderDetailsModel>>
    {
        public int OrderId { get; set; }

        public class GetAllByUserIdHandler : IRequestHandler<GetAllOrderDetailsByOrderIdQuery, IEnumerable<OrderDetailsModel>>
        {
            private readonly DatabaseContext _context;
            public GetAllByUserIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<OrderDetailsModel>> Handle(GetAllOrderDetailsByOrderIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.OrderDetails.Where(a => a.OrderId == request.OrderId).Include(a => a.Product).ToListAsync();

                var getData = new List<OrderDetailsModel>();

                {

                    foreach (var vals in data)
                    {
                        getData.Add(new OrderDetailsModel()
                        {
                            Id = vals.Id,
                            ProductId = vals.ProductId,
                            OrderId = vals.OrderId,
                            DiscountId = vals.DiscountId,
                            Quantity = vals.Quantity,
                            Status = vals.Status,
                            UpdatedAt = vals.UpdatedAt,
                            Price = vals.Product.Price

                        });
                    }

                }

                return getData;
            }
        }
    }
    public class OrderDetailsModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }


        public int OrderId { get; set; }

        public int? DiscountId { get; set; }

        public int Quantity { get; set; }

        public string Status { get; set; } = string.Empty;

        public decimal Price { get; set; } = 0;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;


    }

}




