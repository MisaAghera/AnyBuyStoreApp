
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.AddressHandler.Queries.GetStatesFromCountryId
{

    public class GetStatesFromCountryIdQuery : IRequest<IEnumerable<StateModel>>
    {
        public int CountryId { get; set; }

        public class GetStatesFromCountryIdHandler : IRequestHandler<GetStatesFromCountryIdQuery, IEnumerable<StateModel>>
        {
            private readonly DatabaseContext _context;
            public GetStatesFromCountryIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<StateModel>> Handle(GetStatesFromCountryIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.States.Where(a => a.CountryId == request.CountryId).Include(a=>a.Countries).ToListAsync();

                var getData = new List<StateModel>();

                {
                    foreach (var vals in data)
                    {
                        getData.Add(new StateModel()
                        {
                            Id = vals.Id,
                            CountryId = vals.CountryId,
                            Name = vals.Name,
                            CountryName = vals.Countries.Name

                        });
                    }
                }
                return getData;
            }
        }
    }
    public class StateModel
    {
        public int Id { get; set; }
        public  int? CountryId { get; set; }
        public string? CountryName { get; set; }
        public string Name { get; set; } = string.Empty;
 
    }

}




