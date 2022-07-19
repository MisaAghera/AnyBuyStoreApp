using AnyBuyStore.Data.Data;
using MediatR;
namespace AnyBuyStore.Core.Handlers.AddressHandler.Commands.AddCity
{
    public class AddCityCommand : IRequest<int>
    {
        public AddCityCommand(CityModel @in)
        {
            In = @in;
        }
        public CityModel In { get; set; }
    }

    public class AddCityHandler : IRequestHandler<AddCityCommand, int>
    {
        private readonly DatabaseContext _context;
        public AddCityHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddCityCommand command, CancellationToken cancellationToken)
        {

            var addData = new Cities()
            {
                Id = command.In.Id,
                StateId = command.In.StateId,
                Name = command.In.Name,          
            };

            await _context.AddAsync(addData, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return addData.Id;
        }
    }
    public class CityModel
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; } = string.Empty;

    }

}
