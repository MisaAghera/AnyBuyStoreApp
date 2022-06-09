
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.AddressHandler.Commands.DeleteAddress
{
    public class DeleteAddressCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteAddressHandler : IRequestHandler<DeleteAddressCommand, int>
        {
            private readonly DatabaseContext _context;
            public DeleteAddressHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteAddressCommand command, CancellationToken cancellationToken)
            {
                var deleteData = await _context.Address.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (deleteData != null)
                {
                    _context.Address.Remove(deleteData);
                    await _context.SaveChangesAsync();
                    return deleteData.Id;
                }
                return 0;
            }
        }
    }
}
