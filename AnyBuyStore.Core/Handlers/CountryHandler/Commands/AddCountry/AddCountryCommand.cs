using AnyBuyStore.Data.Data;
using MediatR;
namespace AnyBuyStore.Core.Handlers.AddressHandler.Commands.AddCountry
{
    public class AddCountryCommand : IRequest<int>
    {
        public AddCountryCommand(CountryModel @in)
        {
            In = @in;
        }
        public CountryModel In { get; set; }
    }

    public class AddAddressHandler : IRequestHandler<AddCountryCommand, int>
    {
        private readonly DatabaseContext _context;
        public AddAddressHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddCountryCommand command, CancellationToken cancellationToken)
        {

            var addData = new Countries()
            {
                Id = command.In.Id,
                Name = command.In.Name,
            };

            await _context.AddAsync(addData, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return addData.Id;
        }
    }
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

    }

}
