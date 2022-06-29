using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.AddressHandler.Queries.GetAddressByUserId
{

    public class GetAddressByUserIdQuery : IRequest<IEnumerable<AddressModel>>
    {
        public int UserId { get; set; }

        public class GetAddressByUserIdHandler : IRequestHandler<GetAddressByUserIdQuery, IEnumerable<AddressModel>>
        {
            private readonly DatabaseContext _context;
            public GetAddressByUserIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<AddressModel>> Handle(GetAddressByUserIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.Address.Where(a => a.UserId == request.UserId).ToListAsync();

                var getData = new List<AddressModel>();

                {
                    foreach (var vals in data)
                    {
                        getData.Add(new AddressModel()
                        {
                            Id = vals.Id,
                            OrderId = vals.OrderId,
                            UserId = vals.UserId,
                            House = vals.House,
                            Street = vals.Street,
                            City = vals.City,
                            State = vals.State,
                            Country = vals.Country,
                            ZipCode = vals.ZipCode,
                            AddressType = vals.AddressType,

                        });
                    }
                }


                return getData;
            }
        }
    }
    public class AddressModel
    {
        public int Id { get; set; }
        public virtual int OrderId { get; set; }
        public virtual int? UserId { get; set; }
        public string House { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;

        public string AddressType { get; set; } = string.Empty;
    }

}




