using AnyBuyStore.Data.Data;
using MediatR;

namespace AnyBuyStore.Core.Handlers.AddressHandler.Commands.UpdateCity
{
    public class UpdateCityCommand : IRequest<int>
    {
        public UpdateCityCommand(UpdateCityModel @in)
        {
            In = @in;

        }
        public UpdateCityModel In { get; set; }
    }

    public class UpdateAddressHandler : IRequestHandler<UpdateCityCommand, int>
    {
        private readonly DatabaseContext _context;
        public UpdateAddressHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateCityCommand command, CancellationToken cancellationToken)
        {
            var UpdateData = _context.Cities.Where(a => a.Id == command.In.Id).FirstOrDefault();

            UpdateData.StateId = command.In.StateId;
            UpdateData.Name = command.In.Name;
            UpdateData.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return UpdateData.Id;

        }
    }
    public class UpdateCityModel
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}

