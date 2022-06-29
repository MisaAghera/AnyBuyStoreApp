using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetOrderDetailsById
{

    public class GetOrderDetailsByIdQuery : IRequest<OrderDetailsModel> { public int Id { get; set; }  }

    public class GetOrderDetailsByIdHandler : IRequestHandler<GetOrderDetailsByIdQuery, OrderDetailsModel>
    {
        private readonly DatabaseContext _context;
        public GetOrderDetailsByIdHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<OrderDetailsModel> Handle(GetOrderDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.OrderDetails.Where(a=> a.Id == request.Id).Include(a => a.Product).FirstOrDefaultAsync();
            
                var ModelList = new OrderDetailsModel()
                {
                    Id = data.Id,
                    ProductId = data.ProductId,
                    OrderId = data.OrderId,
                    DiscountId = data.DiscountId,
                    Quantity = data.Quantity,
                    Status = data.Status,
                    UpdatedAt = data.UpdatedAt,
                    Price = data.Product.Price
                };

                return ModelList;
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

