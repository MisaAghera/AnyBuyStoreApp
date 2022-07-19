using AnyBuyStore.Data.Data;
using MediatR;
namespace AnyBuyStore.Core.Handlers.AddressHandler.Commands.AddAddress
{
    public class AddAddressCommand : IRequest<int>
    {
        public AddAddressCommand(AddressModel @in)
        {
            In = @in;
        }
        public AddressModel In { get; set; }
    }

    public class AddAddressHandler : IRequestHandler<AddAddressCommand, int>
    {
        private readonly DatabaseContext _context;
        public AddAddressHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddAddressCommand command, CancellationToken cancellationToken)
        {

            var addData = new Address()
            {
                Id = command.In.Id,
                UserId = command.In.UserId,
                House = command.In.House,
                Street = command.In.Street,
                CityId = command.In.CityId,
                StateId = command.In.StateId,
                CountryId = command.In.CountryId,
                ZipCode = command.In.ZipCode,
                AddressType = command.In.AddressType,
         

            };

            await _context.AddAsync(addData, cancellationToken).ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return addData.Id;
        }
    }
    public class AddressModel
    {

        public int Id { get; set; }
        public virtual int? UserId { get; set; }
        public string House { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }

        public string ZipCode { get; set; } = string.Empty;

        public string AddressType { get; set; } = string.Empty;


    }

}
