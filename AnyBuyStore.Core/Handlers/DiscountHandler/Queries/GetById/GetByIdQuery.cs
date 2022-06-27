using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.DiscountHandler.Queries.GetById
{
    public class GetByIdQuery : IRequest<DiscountModel>
    {

        public int Id { get; set; }
        public class GetAllProductsHandler : IRequestHandler<GetByIdQuery, DiscountModel>
        {
            private readonly DatabaseContext _context;
            public GetAllProductsHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<DiscountModel> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.Discount.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (data != null)
                {
                    var Products = new DiscountModel()
                    {
                        Id = data.Id,
                        Type = data.Type,
                        Value = data.Value,
                        IsActive = data.IsActive,
                    };

                    return Products;
                }
                return null;
            }

        }
    }

    public class DiscountModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public float Value { get; set; }
        public bool IsActive { get; set; }
    }

}

