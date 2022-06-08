using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyBuyStore.Core.Handlers.DiscountHandler.Queries.GetAllDiscounts
{
    internal class GetAllDiscountsQuery
    {
    }
}


//using AnyBuyStore.Data.Data;
//using MediatR;
//using Microsoft.EntityFrameworkCore;

//namespace AnyBuyStore.Core.Handlers.DiscountHandler.Queries.GetAllDiscounts
//{


//    public class GetAllDiscountsQuery : IRequest<IEnumerable<DiscountModel>> { }

//    public class GetAllProductsHandler : IRequestHandler<GetAllProductCetgoriesRequest, IEnumerable<ProductCategoryModel>>
//    {
//        private readonly DatabaseContext _context;
//        public GetAllProductsHandler(DatabaseContext context)
//        {
//            _context = context;
//        }
//        public async Task<IEnumerable<ProductCategoryModel>> Handle(GetAllProductCetgoriesRequest request, CancellationToken cancellationToken)
//        {
//            var data = await _context.Product.ToListAsync();

//            var Products = new List<ProductCategoryModel>();

//            {
//                if (data.Any() == true)
//                {
//                    foreach (var product in data)
//                    {
//                        Products.Add(new ProductCategoryModel()
//                        {
//                            Id = product.Id,
//                            Name = product.Name
//                        });
//                    }
//                }

//            }

//            return Products;
//        }
//        public class DiscountModel
//        {
//            public int Id { get; set; }
//            public virtual int ProductId { get; set; }
//            public int Type { get; set; }
//            public float Value { get; set; }
//        }
//    }

//}


//delete the product Id from discounts