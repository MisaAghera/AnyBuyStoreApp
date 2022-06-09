

using AnyBuyStore.Data.Data;
using MediatR;
namespace AnyBuyStore.Core.Handlers.OrderDetailsHandler.Commands.AddOrderDetails
{
    public class AddOrderDetailsCommand : IRequest<int>
    {
        public AddOrderDetailsCommand(OrderDetailsModel @in)
        {
            In = @in;
        }
        public OrderDetailsModel In { get; set; }
    }

    public class AddOrderDetailsHandler : IRequestHandler<AddOrderDetailsCommand, int>
    {
        private readonly DatabaseContext _context;
        public AddOrderDetailsHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddOrderDetailsCommand command, CancellationToken cancellationToken)
        {

            var addData = new OrderDetails()
            {
                Id = command.In.Id,
                ProductId = command.In.ProductId,
                OrderId = command.In.OrderId,
                DiscountId = command.In.DiscountId,
                Quantity = command.In.Quantity,
                Status = command.In.Status,
                UpdatedAt = DateTime.Now 
            };

            await _context.AddAsync(addData, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return addData.Id;
        }
    }
    public class OrderDetailsModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }


        public int OrderId { get; set; }

        public int? DiscountId { get; set; }

        public int Quantity { get; set; }

        public string Status { get; set; } = string.Empty;

    }

}
