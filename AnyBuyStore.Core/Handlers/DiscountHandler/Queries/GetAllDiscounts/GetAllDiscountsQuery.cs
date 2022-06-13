

using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.DiscountHandler.Queries.GetAllDiscounts
{
    public class GetAllDiscountsQuery : IRequest<IEnumerable<DiscountModel>> { }

    public class GetAllProductsHandler : IRequestHandler<GetAllDiscountsQuery, IEnumerable<DiscountModel>>
    {
        private readonly DatabaseContext _context;
        public GetAllProductsHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DiscountModel>> Handle(GetAllDiscountsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Discount.ToListAsync();

            var Products = new List<DiscountModel>();

            {
               
                    foreach (var product in data)
                    {
                        Products.Add(new DiscountModel()
                        {
                            Id = product.Id,
                            Type = product.Type,
                            Value = product.Value,
                            IsActive = product.IsActive,

                        });
                    }
                

            }

            return Products;
        }
       
    }
    public class DiscountModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public float Value { get; set; }
        public  bool IsActive { get; set; }
    }

}
