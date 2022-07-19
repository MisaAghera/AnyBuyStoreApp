
using AnyBuyStore.Data.Data;
using MediatR;

namespace AnyBuyStore.Core.Handlers.AddressHandler.Commands.UpdateCountry
{
    public class UpdateCountryCommand : IRequest<int>
    {
        public UpdateCountryCommand(UpdateCountryModel @in)
        {
            In = @in;

        }
        public UpdateCountryModel In { get; set; }
    }

    public class UpdateCountryHandler : IRequestHandler<UpdateCountryCommand, int>
    {
        private readonly DatabaseContext _context;
        public UpdateCountryHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateCountryCommand command, CancellationToken cancellationToken)
        {
            var UpdateData = _context.Countries.Where(a => a.Id == command.In.Id).FirstOrDefault();

            UpdateData.Name = command.In.Name;
            UpdateData.UpdatedAt = DateTime.Now;


            await _context.SaveChangesAsync();
            return UpdateData.Id;

        }
    }
    public class UpdateCountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}

