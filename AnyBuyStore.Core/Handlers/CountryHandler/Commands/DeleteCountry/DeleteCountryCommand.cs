using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.AddressHandler.Commands.DeleteCountry
{
    public class DeleteCountryCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteCountryHandler : IRequestHandler<DeleteCountryCommand, int>
        {
            private readonly DatabaseContext _context;
            public DeleteCountryHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteCountryCommand command, CancellationToken cancellationToken)
            {
                var deleteData = await _context.Countries.Where(a => a.Id == command.Id).FirstOrDefaultAsync();

                _context.Countries.Remove(deleteData);
                await _context.SaveChangesAsync();
                return deleteData.Id;

            }
        }
    }
}
