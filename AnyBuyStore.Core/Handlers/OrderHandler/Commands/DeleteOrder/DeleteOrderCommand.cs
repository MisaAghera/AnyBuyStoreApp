
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.OrderHandler.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, int>
        {
            private readonly DatabaseContext _context;
            public DeleteOrderHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
            {
                var deleteData = await _context.Order.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                var OrderDetails = await _context.OrderDetails.Where(a => a.OrderId == command.Id).ToListAsync();
                 
                foreach(var order in OrderDetails)
                {
                    var Product = _context.Product.Join(_context.OrderDetails, product => product.Id, orderDetails => orderDetails.ProductId, (product, orderDetails) => new { Product = product, OrderDetails = orderDetails }).Where(productOrder => productOrder.OrderDetails.Id == order.Id).FirstOrDefault();
                    
                    Product.Product.Quantity = Product.Product.Quantity + order.Quantity ;
                    await _context.SaveChangesAsync();

                }
                    _context.Order.Remove(deleteData);
                    await _context.SaveChangesAsync();
                    return deleteData.Id;
            
            }
        }
    }
}

