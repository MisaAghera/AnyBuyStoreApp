using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.OrderDetailsHandler.Queries.GetOrderDetailsById
{

    public class GetOrderDetailsByIdQuery : IRequest<IEnumerable<OrderDetailsModel>> { }

    public class GetOrderDetailsByIdHandler : IRequestHandler<GetOrderDetailsByIdQuery, IEnumerable<OrderDetailsModel>>
    {
        private readonly DatabaseContext _context;
        public GetOrderDetailsByIdHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderDetailsModel>> Handle(GetOrderDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.OrderDetails.ToListAsync();

            var ModelList = new List<OrderDetailsModel>();

            {
                if (data.Any() == true)
                {
                    foreach (var vals in data)
                    {
                        ModelList.Add(new OrderDetailsModel()
                        {
                           //---------------------logic and other stufdf here
                        });
                    }
                }

            }

            return ModelList;
        }
       
    }
    public class OrderDetailsModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int DeliveryAddressId { get; set; }

        public int OrderId { get; set; }

        public int DiscountId { get; set; }

        public int Quantity { get; set; }

        public string Status { get; set; } = string.Empty;
    }

}


//login is remaining