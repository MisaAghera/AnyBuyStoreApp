using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetAllOrderDetails
{
    public class GetAllOrderDetailsQuery : IRequest<IEnumerable<OrderDetailsModel>> { }

    public class GetAllOrderDetailsHandler : IRequestHandler<GetAllOrderDetailsQuery, IEnumerable<OrderDetailsModel>>
    {
        private readonly DatabaseContext _context;
        public GetAllOrderDetailsHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderDetailsModel>> Handle(GetAllOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.OrderDetails.Include(a => a.Product).ToListAsync();

            var Products = new List<OrderDetailsModel>();

            {
               
                    foreach (var vals in data)
                    {
                        Products.Add(new OrderDetailsModel()
                        {
                            Id = vals.Id,
                            ProductId = vals.ProductId,
                            OrderId = vals.OrderId,
                            DiscountId = vals.DiscountId,
                            Quantity = vals.Quantity,
                            Status = vals.Status,
                            UpdatedAt = vals.UpdatedAt,
                            Price = vals.Product.Price,
                        });
                    }
                }

           

            return Products;
        }
    }
    public class OrderDetailsModel
    {
        public int Id { get; set; }
        public  int ProductId { get; set; }


        public  int OrderId { get; set; }

        public  int? DiscountId { get; set; }

        public int Quantity { get; set; }

        public string Status { get; set; } = string.Empty;

        public decimal Price { get; set; } = 0;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;


    }
}


//login is remaining
