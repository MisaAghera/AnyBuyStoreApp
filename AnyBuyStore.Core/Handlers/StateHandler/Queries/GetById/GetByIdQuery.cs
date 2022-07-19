
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.StateHandler.Queries.GetById
{

    public class GetByIdQuery : IRequest<StateModel>
    {
        public int Id { get; set; }


        public class GetByIdHandler : IRequestHandler<GetByIdQuery, StateModel>
        {
            private readonly DatabaseContext _context;
            public GetByIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<StateModel> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                var vals = await _context.States.Where(a => a.Id == request.Id).Include(a => a.Countries).FirstOrDefaultAsync();
                if (vals != null)
                {
                    var address = new StateModel()
                    {
                        Id = vals.Id,
                        CountryId = vals.CountryId,
                        Name = vals.Name,
                        CountryName = vals.Countries.Name

                    };
                    return address;
                }
                return null;
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


