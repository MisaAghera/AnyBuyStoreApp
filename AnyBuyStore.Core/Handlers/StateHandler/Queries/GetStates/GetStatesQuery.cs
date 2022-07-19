using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.AddressHandler.Queries.GetStates
{

    public class GetStatesQuery : IRequest<IEnumerable<StateModel>>
    {

        public class GetStatesHandler : IRequestHandler<GetStatesQuery, IEnumerable<StateModel>>
        {
            private readonly DatabaseContext _context;
            public GetStatesHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<StateModel>> Handle(GetStatesQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.States.Include(a => a.Countries).ToListAsync();

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
        public int? CountryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? CountryName { get; set; }

    }

}




