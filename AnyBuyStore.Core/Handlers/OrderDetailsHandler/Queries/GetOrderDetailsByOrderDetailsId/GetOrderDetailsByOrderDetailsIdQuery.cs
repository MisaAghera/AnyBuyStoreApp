using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetOrderDetailsByOrderDetailsId
{
    

    public class GetOrderDetailsByOrderDetailsIdQuery : IRequest<OrderDetailsDetailsModel>
    {
        public int Id { get; set; }


        public class GetOrderDetailsByOrderDetailsIdHandler : IRequestHandler<GetOrderDetailsByOrderDetailsIdQuery, OrderDetailsDetailsModel>
        {
            private readonly DatabaseContext _context;
            public GetOrderDetailsByOrderDetailsIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<OrderDetailsDetailsModel> Handle(GetOrderDetailsByOrderDetailsIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.OrderDetails.Where(a => a.Id == request.Id).Include(a => a.Product).FirstOrDefaultAsync();
                if (data != null)
                {
                    var product = new OrderDetailsDetailsModel()
                    {
                        Id = data.Id,
                        ProductId = data.ProductId,
                        OrderId = data.OrderId,
                        DiscountId = data.DiscountId,
                        Quantity = data.Quantity,
                        Status = data.Status,
                        UpdatedAt = data.UpdatedAt,
                        Price = data.Product.Price,
                        ProductName = data.Product.Name,

                    };
                    return product;
                }
                return null;
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


