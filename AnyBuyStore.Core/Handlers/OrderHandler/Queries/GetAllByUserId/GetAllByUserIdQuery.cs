using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.OrderHandler.Queries.GetAllByUserId
{
    public class GetAllByUserIdQuery : IRequest<IEnumerable<OrderModel>>
    {
        public int UserId { get; set; }

        public class GetAllByUserIdHandler : IRequestHandler<GetAllByUserIdQuery, IEnumerable<OrderModel>>
        {
            private readonly DatabaseContext _context;
            public GetAllByUserIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<OrderModel>> Handle(GetAllByUserIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.Order.Where(a => a.UserId == request.UserId).Include(a => a.Address).Include(a => a.User).ToListAsync();

                var getData = new List<OrderModel>();

                {

                    foreach (var vals in data)
                    {
                        getData.Add(new OrderModel()
                        {
                            Id = vals.Id,
                            AddressId = vals.AddressId,
                            UserId = vals.UserId,
                            TotalAmount = vals.TotalAmount,
                            TotalDiscount = vals.TotalDiscount,
                            UpdatedAt = vals.UpdatedAt,
                            //AddressCity = vals.Address.CityId,
                            UserName = vals.User.UserName
                        });
                    }

                }

                return getData;
            }
        }
    }
    public class OrderModel
    {
        public int Id { get; set; }


        public string UserName { get; set; }

        public string AddressCity { get; set; }

        public int AddressId { get; set; }

        public int UserId { get; set; }

        public decimal? TotalAmount { get; set; }

        public decimal? TotalDiscount { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }

}




