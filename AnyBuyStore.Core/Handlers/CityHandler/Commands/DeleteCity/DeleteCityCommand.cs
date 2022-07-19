using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.AddressHandler.Commands.DeleteCity
{
    public class DeleteCityCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteCityHandler : IRequestHandler<DeleteCityCommand, int>
        {
            private readonly DatabaseContext _context;
            public DeleteCityHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteCityCommand command, CancellationToken cancellationToken)
            {
                var deleteData = await _context.Cities.Where(a => a.Id == command.Id).FirstOrDefaultAsync();

                _context.Cities.Remove(deleteData);
                await _context.SaveChangesAsync();
                return deleteData.Id;

            }
        }
    }
}
