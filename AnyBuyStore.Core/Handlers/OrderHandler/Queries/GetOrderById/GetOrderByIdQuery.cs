
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
                var vals = await _context.Order.Where(a => a.Id == request.Id).Include(a=>a.Address).Include(a=>a.User).FirstOrDefaultAsync();

                    var Product = new OrderModel()
                    {
                        Id = vals.Id,
                        UserId = vals.UserId,
                        AddressId = vals.AddressId,
                        TotalAmount = vals.TotalAmount,
                        UpdatedAt = vals.UpdatedAt,
                        UserName = vals.User.UserName
                    };
                    return Product;   
            }
        }
    }
    public class OrderModel
    {
        public int Id { get; set; }

        public int AddressId { get; set; }

        public string? UserName { get; set; }

        public int UserId { get; set; }

        public decimal? TotalAmount { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}


