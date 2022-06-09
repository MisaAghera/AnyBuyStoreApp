
using AnyBuyStore.Data.Data;
using MediatR;

namespace AnyBuyStore.Core.Handlers.ProductSubCategoryHandler.Commands.UpdateDiscount
{
    public class UpdateDiscountCommand : IRequest<int>
    {
        public UpdateDiscountCommand(UpdateDiscountModel @in)
        {
            In = @in;

        }
        public UpdateDiscountModel In { get; set; }
    }

    public class UpdateDiscountHandler : IRequestHandler<UpdateDiscountCommand, int>
    {
        private readonly DatabaseContext _context;
        public UpdateDiscountHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateDiscountCommand command, CancellationToken cancellationToken)
        {
            var UpdateData = _context.Discount.Where(a => a.Id == command.In.Id).FirstOrDefault();
            if (UpdateData == null)
            {
                return default;
            }
            else
            {
                UpdateData.Id = command.In.Id;
                UpdateData.Type = command.In.Type;
                UpdateData.Value = command.In.Value;
                UpdateData.IsActive = command.In.IsActive;
                UpdateData.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();
                return UpdateData.Id;
            }
        }
    }
    public class UpdateDiscountModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public float Value { get; set; }
        public bool IsActive { get; set; }
    }
}

