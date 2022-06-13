
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Queries.GetAddressByOrderIdQuery
{
    public class GetAddressByOrderIdQuery : IRequest<IEnumerable<AddressModel>>
    {
        public int OrderDetailsId { get; set; }

        public class GetAllProductsHandler : IRequestHandler<GetAddressByOrderIdQuery, IEnumerable<AddressModel>>
        {
            private readonly DatabaseContext _context;
            public GetAllProductsHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<AddressModel>> Handle(GetAddressByOrderIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.Address.Where(a => a.OrderDetailsId == request.OrderDetailsId).ToListAsync();

                var getData = new List<AddressModel>();

                {
                    if (data.Any() == true)
                    {
                        foreach (var vals in data)
                        {
                            getData.Add(new AddressModel()
                            {
                                Id = vals.Id,
                                OrderDetailsId = vals.OrderDetailsId,
                                UserId = vals.UserId,
                                House = vals.House,
                                Street = vals.Street,
                                City = vals.City,
                                State = vals.State,
                                Country = vals.Country,
                                ZipCode = vals.ZipCode,
                                AddressType = vals.AddressType,

                            });
                        }
                    }
                }
                if (getData.Count == 0)
                {
                    return null;
                }
                return getData;
            }
        }
    }
    public class AddressModel
    {
        public int Id { get; set; }    
        public virtual int OrderDetailsId { get; set; }
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




