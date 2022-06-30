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
                var vals = await _context.Address.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (vals != null)
                {
                    var address = new AddressModel()
                    {
                        Id = vals.Id,
                        UserId = vals.UserId,
                        House = vals.House,
                        Street = vals.Street,
                        City = vals.City,
                        State = vals.State,
                        Country = vals.Country,
                        ZipCode = vals.ZipCode,
                        AddressType = vals.AddressType,
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

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;

        public string AddressType { get; set; } = string.Empty;
    }

}


