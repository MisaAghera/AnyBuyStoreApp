
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Queries.GetAddressByOrderIdQuery
{
    public class GetAddressByOrderIdQuery : IRequest<AddressModel>
    {
        public int OrderDetailsId { get; set; }

        public class GetAddressByOrderIdHandler : IRequestHandler<GetAddressByOrderIdQuery, AddressModel>
        {
            private readonly DatabaseContext _context;
            public GetAddressByOrderIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<AddressModel> Handle(GetAddressByOrderIdQuery request, CancellationToken cancellationToken)
            {
                var vals = await _context.Address.Where(a => a.OrderId == request.OrderDetailsId).FirstOrDefaultAsync();

                var getData = new AddressModel()
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

                };

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




