
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Queries.GetAddressByOrderIdQuery
{
    public class GetAddressByOrderIdQuery : IRequest<AddressModel>
    {
        public int OrderId { get; set; }

        public class GetAddressByOrderIdHandler : IRequestHandler<GetAddressByOrderIdQuery, AddressModel>
        {
            private readonly DatabaseContext _context;
            public GetAddressByOrderIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<AddressModel> Handle(GetAddressByOrderIdQuery request, CancellationToken cancellationToken)
            {
                var vals = await _context.Order.Where(a => a.Id == request.OrderId).Include(a=>a.Address).ThenInclude(a => a.Countries).ThenInclude(a => a.States).ThenInclude(a => a.Cities).FirstOrDefaultAsync();

                var getData = new AddressModel()
                {
                    Id = vals.Address.Id,
                    UserId = vals.Address.UserId,
                    House = vals.Address.House,
                    Street = vals.Address.Street,
                    CityId = vals.Address.CityId,
                    StateId = vals.Address.StateId,
                    CountryId = vals.Address.CountryId,
                    ZipCode = vals.Address.ZipCode,
                    AddressType = vals.Address.AddressType,
                    Country = vals.Address.Countries.Name,
                    City = vals.Address.Cities.Name,
                    State = vals.Address.States.Name,
                };

                return getData;
            }
        }
    }
    public class AddressModel
    {
        public int Id { get; set; }
        public virtual int? UserId { get; set; }
        public string House { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string ZipCode { get; set; } = string.Empty;

        public string AddressType { get; set; } = string.Empty;
    }

}




