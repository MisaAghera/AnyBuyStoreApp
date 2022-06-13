
using AnyBuyStore.Data.Data;
using MediatR;

namespace AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Commands.UpdateProductSubCategory
{
    public class UpdateOrderDetailsCommand : IRequest<int>
    {
        public UpdateOrderDetailsCommand(UpdateOrderDetailsModel @in)
        {
            In = @in;

        }
        public UpdateOrderDetailsModel In { get; set; }
    }

    public class UpdateOrderDetailsHandler : IRequestHandler<UpdateOrderDetailsCommand, int>
    {
        private readonly DatabaseContext _context;
        public UpdateOrderDetailsHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateOrderDetailsCommand command, CancellationToken cancellationToken)
        {
            var UpdateData = _context.OrderDetails.Where(a => a.Id == command.In.Id).FirstOrDefault();
           
                UpdateData.Id = command.In.Id;
                UpdateData.ProductId = command.In.ProductId;
                UpdateData.OrderId = command.In.OrderId;
                UpdateData.DiscountId = command.In.DiscountId;
                UpdateData.Quantity = command.In.Quantity;
                UpdateData.Status = command.In.Status;
                UpdateData.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();
                return UpdateData.Id;
            
        }
    }
    public class UpdateOrderDetailsModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }


        public int OrderId { get; set; }

        public int? DiscountId { get; set; }

        public int Quantity { get; set; }

        public string Status { get; set; } = string.Empty;

    }
}

