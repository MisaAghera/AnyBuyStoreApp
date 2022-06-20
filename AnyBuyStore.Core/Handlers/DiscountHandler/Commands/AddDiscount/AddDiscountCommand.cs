using AnyBuyStore.Data.Data;
using MediatR;
namespace AnyBuyStore.Core.Handlers.DiscountHandler.Commands.AddDiscount
{
    public class AddDiscountCommand : IRequest<int>
    {
        public AddDiscountCommand(DiscountModel @in)
        {
            In = @in;
        }
        public DiscountModel In { get; set; }
    }

    public class AddDiscountHandler : IRequestHandler<AddDiscountCommand, int>
    {
        private readonly DatabaseContext _context;
        public AddDiscountHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddDiscountCommand command, CancellationToken cancellationToken)
        {

            var addData = new Discount()
            {
                Type = command.In.Type,
                Value = command.In.Value,
                IsActive = true,

            };

            await _context.AddAsync(addData, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return addData.Id;
        }
    }
    public class DiscountModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public float Value { get; set; }
        public bool IsActive { get; set; }
    }

}
