

using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductCartHandler.Queries.GetAllCartProductsById
{
    public class GetAllCartProductByIdQuery : IRequest<IEnumerable<ProductCartGetModel>>
    {
        public int UserId { get; set; }

        public class GetAllCartProductByIdHandler : IRequestHandler<GetAllCartProductByIdQuery, IEnumerable<ProductCartGetModel>>
        {
            private readonly DatabaseContext _context;
            public GetAllCartProductByIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<ProductCartGetModel>> Handle(GetAllCartProductByIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.ProductCart.Where(a => a.UserId == request.UserId).Include(a=> a.Product).ToListAsync();

                var getData = new List<ProductCartGetModel>();

                {
                   
                        foreach (var vals in data)
                        {
                            getData.Add(new ProductCartGetModel()
                            {
                                Id = vals.Id,
                                UserId = vals.UserId,
                                ProductId = vals.ProductId,
                                Quantity = vals.Quantity,
                                IsAvailable = vals.IsAvailable,
                                ProductPrice = vals.Product.Price,
                                ProductName = vals.Product.Name,
                                ProductImgUrl = vals.Product.ImageUrl,
                                ActualProductQuantity = vals.Product.Quantity,
                            });
                        }
                    
                }

                return getData;
            }
        }
    }
    public class ProductCartGetModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual int ProductId { get; set; }

        public  string ProductImgUrl { get; set; }

        public int ActualProductQuantity { get; set; }

        public int Quantity { get; set; }
        public decimal? ProductPrice { get; set; }
        public string? ProductName { get; set; }
        public bool IsAvailable { get; set; }

    }

}




