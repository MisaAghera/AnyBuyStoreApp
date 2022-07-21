
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.OrderDetailsHandler.Commands.DeleteOrderDetailsCommand
{

    public class DeleteOrderDetailsCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductSubcategoryHandler : IRequestHandler<DeleteOrderDetailsCommand, int>
        {
            private readonly DatabaseContext _context;
            public DeleteProductSubcategoryHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteOrderDetailsCommand command, CancellationToken cancellationToken)
            {

                var deleteData = await _context.OrderDetails.Where(a => a.Id == command.Id).FirstOrDefaultAsync();

                var Product = _context.Product.Join(_context.OrderDetails, product => product.Id, orderDetails => orderDetails.ProductId, (product, orderDetails) => new { Product = product, OrderDetails = orderDetails }
               ).Where(productOrder=> productOrder.OrderDetails.Id == command.Id ).FirstOrDefault();

                Product.Product.Quantity = Product.Product.Quantity + deleteData.Quantity;
                await _context.SaveChangesAsync();

                var Order = _context.Order.Where(a => a.Id == deleteData.OrderId).FirstOrDefault();
                Order.TotalAmount = Order.TotalAmount - (deleteData.Quantity * Product.Product.Price);
                await _context.SaveChangesAsync();

                _context.OrderDetails.Remove(deleteData);
                    await _context.SaveChangesAsync();
                    return deleteData.Id;   
               
            }
        }
    }
}
