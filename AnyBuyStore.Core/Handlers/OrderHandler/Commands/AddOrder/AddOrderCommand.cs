using AnyBuyStore.Data.Data;
using MediatR;
namespace AnyBuyStore.Core.Handlers.ProductHandler.Commands.CreateProduct

{
    public class AddOrderCommand : IRequest<int>
    {
        public AddOrderCommand(OrderModel @in)
        {
            In = @in;
        }
        public OrderModel In { get; set; }
    }

    public class AddOrderHandler : IRequestHandler<AddOrderCommand, int>
    {
        private readonly DatabaseContext _context;
        public AddOrderHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddOrderCommand command, CancellationToken cancellationToken)
        {

            var addData = new Order()
            {
                Id = command.In.Id,
                UserId = command.In.UserId,
                TotalAmount = command.In.TotalAmount,
                TotalDiscount = command.In.TotalDiscount,
            };

            await _context.AddAsync(addData, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return addData.Id;
        }
    }
    public class OrderModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal? TotalDiscount { get; set; }
    }

}
