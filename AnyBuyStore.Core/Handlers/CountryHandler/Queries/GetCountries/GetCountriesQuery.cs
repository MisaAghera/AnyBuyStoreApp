
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.AddressHandler.Queries.GetCountries

{
    public class GetCountriesQuery : IRequest<IEnumerable<CountryModel>>
    {

        public class GetCountriesHandler : IRequestHandler<GetCountriesQuery, IEnumerable<CountryModel>>
        {
            private readonly DatabaseContext _context;
            public GetCountriesHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<CountryModel>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.Countries.ToListAsync();

                var getData = new List<CountryModel>();

                {
                    foreach (var vals in data)
                    {
                        getData.Add(new CountryModel()
                        {
                            Id = vals.Id,
                            Name = vals.Name
                        });
                    }
                }
                return getData;
            }
        }
    }
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

    }

}




