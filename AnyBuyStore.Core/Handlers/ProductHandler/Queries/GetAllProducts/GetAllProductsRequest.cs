﻿using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductHandler.Queries.GetAllProducts
{

    public class GetAllProductsRequest : IRequest<IEnumerable<ProductModel>> { }

    public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, IEnumerable<ProductModel>>
    {
        private readonly DatabaseContext _context;
        public GetAllProductsHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductModel>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var data = await _context.Product.ToListAsync();


            var Products = new List<ProductModel>();
           
                foreach (var product in data)
                {
                    Products.Add(new ProductModel()
                    {
                        Id = product.Id,
                        UserId = product.UserId,
                        DiscountId = product.DiscountId,
                        ProductSubcategoryId = product.ProductSubcategoryId,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        Brand = product.Brand,
                        ImageUrl = product.ImageUrl,
                        Quantity = product.Quantity
                    });
                }
            
            return Products;
        }
    }

    public class ProductModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? DiscountId { get; set; }
        public int ProductSubcategoryId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; } = String.Empty;
        public string ImageUrl { get; set; } = String.Empty;
        public int Quantity { get; set; } = 1;

    }

}
