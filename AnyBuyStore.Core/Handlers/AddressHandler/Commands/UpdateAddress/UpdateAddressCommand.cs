
using AnyBuyStore.Data.Data;
using MediatR;

namespace AnyBuyStore.Core.Handlers.AddressHandler.Commands.UpdateAddress
{
    public class UpdateAddressCommand : IRequest<int>
    {
        public UpdateAddressCommand(UpdateAddressModel @in)
        {
            In = @in;

        }
        public UpdateAddressModel In { get; set; }
    }

    public class UpdateAddressHandler : IRequestHandler<UpdateAddressCommand, int>
    {
        private readonly DatabaseContext _context;
        public UpdateAddressHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateAddressCommand command, CancellationToken cancellationToken)
        {
            var UpdateData = _context.Address.Where(a => a.Id == command.In.Id).FirstOrDefault();
           
                UpdateData.House = command.In.House;
                UpdateData.Street = command.In.Street;
                UpdateData.CityId = command.In.CityId;
                UpdateData.StateId = command.In.StateId;
                UpdateData.CountryId = command.In.CountryId;
                UpdateData.ZipCode = command.In.ZipCode;
                UpdateData.AddressType = command.In.AddressType;
                UpdateData.UpdatedAt = DateTime.Now;


                await _context.SaveChangesAsync();
                return UpdateData.Id;
            
        }
    }
    public class UpdateAddressModel
    {

        public int Id { get; set; }
        public  int? UserId { get; set; }
        public string House { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int? CountryId { get; set; }
        public  int? CityId { get; set; }
        public  int? StateId { get; set; }
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string AddressType { get; set; } = string.Empty;


    }
}

