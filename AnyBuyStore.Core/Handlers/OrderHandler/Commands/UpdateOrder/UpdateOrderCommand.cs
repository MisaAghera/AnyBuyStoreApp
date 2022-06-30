

using AnyBuyStore.Data.Data;
using MediatR;

namespace AnyBuyStore.Core.Handlers.ProductCategoryHandler.Commands.UpdateProducCategory
{
    public class UpdateOrderCommand : IRequest<int>
    {
        public UpdateOrderCommand(UpdateOrderModel @in)
        {
            In = @in;

        }
        public UpdateOrderModel In { get; set; }
    }

    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, int>
    {
        private readonly DatabaseContext _context;
        public UpdateOrderHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            var UpdateData = _context.Order.Where(a => a.Id == command.In.Id).FirstOrDefault();

            UpdateData.Id = command.In.Id;
            UpdateData.AddressId = command.In.AddressId;
            UpdateData.UserId = command.In.UserId;
            UpdateData.TotalAmount = command.In.TotalAmount;
            UpdateData.TotalDiscount = command.In.TotalDiscount;
            UpdateData.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return UpdateData.Id;
        }
    }
    public class UpdateOrderModel
    {

        public int Id { get; set; }

        public int AddressId { get; set; }

        public int UserId { get; set; }

        public decimal? TotalAmount { get; set; }

        public decimal? TotalDiscount { get; set; }
    }

}




