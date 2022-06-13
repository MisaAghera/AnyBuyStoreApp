using AnyBuyStore.Data.Data;
using MediatR;
namespace AnyBuyStore.Core.Handlers.ProductWishHandler.Commands.AddProductWish
{
    public class AddProductwishCommand : IRequest<int>
    {
        public AddProductwishCommand(ProductWishModel @in)
        {
            In = @in;
        }
        public ProductWishModel In { get; set; }
    }

    //public class AddProductwishHandler : IRequestHandler<AddProductwishCommand, int>
    //{
    //    private readonly DatabaseContext _context;
    //    public AddProductwishHandler(DatabaseContext context)
    //    {
    //        _context = context;
    //    }
    //    public async Task<int> Handle(AddProductwishCommand command, CancellationToken cancellationToken)
    //    {
    //        var addData = new ProductWish()
    //        {
    //            Id = command.In.Id,
    //            UserId = command.In.UserId,
    //            ProductId = command.In.ProductId,
    //        };
    //        await _context.AddAsync(addData, cancellationToken).ConfigureAwait(false);
    //        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    //        return addData.Id;
    //    }
    //}
    public class ProductWishModel
    {
        public int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual int ProductId { get; set; }
    }
}
