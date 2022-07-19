using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.CountryHandler.Queries.GetById
{

    public class GetByIdQuery : IRequest<CountryModel>
    {
        public int Id { get; set; }


        public class GetByIdHandler : IRequestHandler<GetByIdQuery, CountryModel>
        {
            private readonly DatabaseContext _context;
            public GetByIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<CountryModel> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                var vals = await _context.Countries.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (vals != null)
                {
                    var address = new CountryModel()
                    {
                        Id = vals.Id,
                        Name = vals.Name
                    };
                    return address;
                }
                return null;
            }
        }
    }
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}


