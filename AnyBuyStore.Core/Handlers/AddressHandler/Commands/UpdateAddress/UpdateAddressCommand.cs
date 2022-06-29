
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
           
                UpdateData.Id = command.In.Id;
                UpdateData.House = command.In.House;
                UpdateData.Street = command.In.Street;
                UpdateData.City = command.In.City;
                UpdateData.State = command.In.State;
                UpdateData.Country = command.In.Country;
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
        public virtual int OrderId { get; set; }
        public virtual int? UserId { get; set; }
        public string House { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;

        public string AddressType { get; set; } = string.Empty;


    }
}

