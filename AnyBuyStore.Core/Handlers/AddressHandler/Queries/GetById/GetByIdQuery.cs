using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.AddressHandler.Queries.GetById
{

    public class GetByIdQuery : IRequest<AddressModel>
    {
        public int Id { get; set; }


        public class GetByIdHandler : IRequestHandler<GetByIdQuery, AddressModel>
        {
            private readonly DatabaseContext _context;
            public GetByIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<AddressModel> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                var vals = await _context.Address.Where(a => a.Id == request.Id).Include(a=>a.Countries).Include(a => a.States).Include(a => a.Cities).FirstOrDefaultAsync();
                if (vals != null)
                {
                    var address = new AddressModel()
                    {
                        Id = vals.Id,
                        UserId = vals.UserId,
                        House = vals.House,
                        Street = vals.Street,
                        StateId = vals.StateId,
                        CityId = vals.CityId,
                        CountryId = vals.CountryId,
                        ZipCode = vals.ZipCode,
                        AddressType = vals.AddressType,
                        Country = vals.Countries.Name,
                        City = vals.Cities.Name,
                        State = vals.States.Name,

                    };
                    return address;
                }
                return null;
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


