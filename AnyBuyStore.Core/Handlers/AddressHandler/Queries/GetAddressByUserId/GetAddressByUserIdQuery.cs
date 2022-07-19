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
                var data =  _context.Address.Where(a => a.UserId == request.UserId).ToList().GroupBy(x => x.AddressType, (key, group) => group.First());

                var getData = new List<AddressModel>();

                {
                    foreach (var vals in data)
                    {
                        getData.Add(new AddressModel()
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
        public virtual int? UserId { get; set; }
        public string House { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }

        public string ZipCode { get; set; } = string.Empty;

        public string AddressType { get; set; } = string.Empty;
    }

}




