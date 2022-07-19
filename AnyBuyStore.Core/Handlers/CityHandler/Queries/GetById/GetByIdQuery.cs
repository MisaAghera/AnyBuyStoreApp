using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.CityHandler.Queries.GetById
{

    public class GetByIdQuery : IRequest<CityModel>
    {
        public int Id { get; set; }


        public class GetByIdHandler : IRequestHandler<GetByIdQuery, CityModel>
        {
            private readonly DatabaseContext _context;
            public GetByIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<CityModel> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                var vals = await _context.Cities.Where(a => a.Id == request.Id).Include(a => a.States).FirstOrDefaultAsync();
                if (vals != null)
                {
                    var address = new CityModel()
                    {
                        Id = vals.Id,
                        StateId = vals.StateId,
                        StateName= vals.States.Name,
                        Name = vals.Name
                    };
                    return address;
                }
                return null;
            }
        }
    }
    public class CityModel
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? StateName { get; set; }

    }
}


